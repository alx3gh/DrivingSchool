using DrivingSchool.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using Microsoft.EntityFrameworkCore;
using DrivingSchool.Models;
using DrivingSchool.ViewModels.DriversVM;

namespace DrivingSchool.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class DriversController : Controller
    {
        private readonly DrivingSchoolDbContext _context;

        public DriversController(DrivingSchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateDrivers(int trackId)
        {
            var viewModel = new CreateDriversViewModel
            {
                TrackId = trackId
            };

            ViewBag.TrackId = trackId;
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateDrivers(CreateDriversViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var drivers = new Drivers
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    ImageUrl = viewModel.ImageUrl,
                    Bio = viewModel.Bio,
                    TrackId = viewModel.TrackId
                };

                _context.Drivers.Add(drivers);
                await _context.SaveChangesAsync();

                return RedirectToAction("TrackDetails", "Track", new { id = drivers.TrackId });
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsDrivers(int id)
        {
            var drivers = await _context.Drivers
                .Include(t => t.Track)
                .Include(t => t.Lessons)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (drivers == null)
            {
                return NotFound("Drivers not found.");
            }

            var driversViewModel = new DetailsDriversViewModel
            {
                Id = drivers.Id,
                Name = drivers.Name,
                Age = drivers.Age,
                Bio = drivers.Bio,
                ImageUrl = drivers.ImageUrl,
                Track = drivers.Track,
                Lessons = drivers.Lessons.ToList()
            };

            return View(driversViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditDrivers(int id)
        {
            var drivers = await _context.Drivers.FirstOrDefaultAsync(t => t.Id == id);
            if (drivers == null)
            {
                return NotFound("Drivers not found.");
            }

            var driversView = new EditDriversViewModel
            {
                Id = drivers.Id,
                Name = drivers.Name,
                Age = drivers.Age,
                Bio = drivers.Bio,
                ImageUrl = drivers.ImageUrl,
            };

            return View(driversView);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditDrivers(EditDriversViewModel drivers)
        {
            var driversToEdit = await _context.Drivers.FindAsync(drivers.Id);
            if (driversToEdit == null)
            {
                return NotFound();
            }

            driversToEdit.Name = drivers.Name;
            driversToEdit.Age = drivers.Age;
            driversToEdit.Bio = drivers.Bio;
            driversToEdit.ImageUrl = drivers.ImageUrl;

            if (ModelState.IsValid)
            {
                _context.Drivers.Update(driversToEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailsDrivers", new { id = drivers.Id });
            }

            return View(drivers);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteDrivers(int id)
        {
            var drivers = await _context.Drivers.FirstOrDefaultAsync(t => t.Id == id);
            if (drivers == null)
            {
                return NotFound("Drivers not found.");
            }

            _context.Drivers.Remove(drivers);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrackDetails", "Track", new { id = drivers.TrackId });
        }
    }
}
