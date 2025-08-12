using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DrivingSchool.Data;
using DrivingSchool.Models;
using DrivingSchool.ViewModels.CarsVM;


namespace DrivingSchool.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class CarsController : Controller
    {

        private readonly DrivingSchoolDbContext _context;

        public CarsController(DrivingSchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateCars(int activityId)
        {
            var model = new CreateCarsViewModel()
            {
                ActivityId = activityId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCars(CreateCarsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var cars = new Cars
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description
            };

            _context.Cars.Add(cars);
            await _context.SaveChangesAsync();

            return RedirectToAction("AddCars", "Cars", new { activityId = model.ActivityId });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCars(int id, int? activityId = null)
        {
            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound("Cars not found.");
            }

            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();

            if (activityId.HasValue)
            {
                return RedirectToAction("AddCars", "Cars", new { activityId = activityId.Value });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult AddCars(int activityId, int page = 1, int pageSize = 6)
        {
            var activity = _context.Activity
                .Include(c => c.CarsAvailable)
                .ThenInclude(ca => ca.Cars)
                .FirstOrDefault(c => c.Id == activityId);

            if (activity == null)
            {
                return NotFound();
            }

            var allCars = _context.Cars.ToList();
            var paginatedCars = allCars
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalCars = allCars.Count;

            var model = new CurrentCarsViewModel
            {
                ActivityId = activityId,
                ActivityName = activity.Name,
                Cars = paginatedCars,
                SelectedCars = activity.CarsAvailable.Select(ca => ca.CarsId).ToList(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCars / (double)pageSize)
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddCars(int ActivityId, int CarsId)
        {
            var activity = await _context.Activity.Include(c => c.CarsAvailable).FirstOrDefaultAsync(c => c.Id == ActivityId);
            var cars = await _context.Cars.FindAsync(CarsId);

            if (activity == null || cars == null)
            {
                return NotFound();
            }

            if (!activity.CarsAvailable.Any(ca => ca.CarsId == CarsId))
            {
                _context.CarsAvailable.Add(new CarsAvailable
                {
                    ActivityId = ActivityId,
                    CarsId = CarsId
                });
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("AddCars", new { activityId = ActivityId });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveCars(int ActivityId, int CarsId)
        {

            var activityCars = _context.CarsAvailable
                .FirstOrDefault(ca => ca.ActivityId == ActivityId && ca.CarsId == CarsId);

            if (activityCars != null)
            {
                _context.CarsAvailable.Remove(activityCars);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("AddCars", new { activityId = ActivityId });
        }
    }
}
