using DrivingSchool.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    
using DrivingSchool.Models;
using DrivingSchool.ViewModels.LessonsVM;

namespace DrivingSchool.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LessonsController : Controller
    {
        private readonly DrivingSchoolDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public LessonsController(DrivingSchoolDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateLessons(int driversId)
        {
            var drivers = await _context.Drivers.FirstOrDefaultAsync(t => t.Id == driversId);
            if (drivers == null)
            {
                return NotFound();
            }

            var viewModel = new LessonsViewModel
            {
                DriversId = driversId,
            };

            return View(viewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateLessons(LessonsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var lessons = new Lessons
            {
                DriversId = model.DriversId,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description
            };

            _context.Lessons.Add(lessons);
            await _context.SaveChangesAsync();
            return RedirectToAction("DetailsDrivers", "Drivers", new { id = lessons.DriversId });
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddToMyLessons(int lessonsId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var lessons = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonsId);
            if (lessons == null)
            {
                return NotFound();
            }

            var isAlreadyAdded = await _context.UserLessons
                .AnyAsync(ul => ul.UserId == user.Id && ul.LessonsId == lessonsId);


            if (!isAlreadyAdded)
            {
                _context.UserLessons.Add(new UserLessons
                {
                    UserId = user.Id,
                    LessonsId = lessonsId
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "MyLessons");
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveFromMyLessons(int lessonsId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var userLessons = await _context.UserLessons
                .FirstOrDefaultAsync(ul => ul.UserId == user.Id && ul.LessonsId == lessonsId);

            if (userLessons != null)
            {
                _context.UserLessons.Remove(userLessons);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "MyLessons");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteLessons(int id)
        {
            var lessons = await _context.Lessons
                .Include(l => l.UserLessons)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lessons == null)
            {
                return NotFound();
            }

            _context.UserLessons.RemoveRange(lessons.UserLessons);

            _context.Lessons.Remove(lessons);

            await _context.SaveChangesAsync();

            return RedirectToAction("DetailsDrivers", "Drivers", new { id = lessons.DriversId });
        }
    }
}
