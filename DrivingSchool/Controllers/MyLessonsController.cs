using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DrivingSchool.Data;
using DrivingSchool.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DrivingSchool.ViewModels;

namespace DrivingSchool.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class MyLessonsController : Controller
    {
        private readonly DrivingSchoolDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MyLessonsController(DrivingSchoolDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var lessons = await _context.UserLessons
                .Where(ul => ul.UserId == user.Id)
                .Select(ul => ul.Lessons)
                .ToListAsync();


            foreach (var lesson in lessons)
            {
                var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == lesson.DriversId);
                var track = await _context.Track.FirstOrDefaultAsync(t => t.Id == driver.TrackId);
                driver.Track = track;
                lesson.Drivers = driver;
            }

            return View(lessons);
        }
    }
}
