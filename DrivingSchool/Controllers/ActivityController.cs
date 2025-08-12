using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrivingSchool.Data;
using DrivingSchool.Models;
using DrivingSchool.ViewModels.ActivityVM;


namespace DrivingSchool.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ActivityController : Controller
    {
        private readonly DrivingSchoolDbContext _context;

        public ActivityController(DrivingSchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateActivity(int activityId)
        {
            var activity = new CreateActivityViewModel
            {
                TrackId = activityId
            };

            return View(activity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(CreateActivityViewModel activity)
        {
            ViewBag.TrackId = activity.TrackId;

            if (ModelState.IsValid)
            {
                var activityEntity = new Activity
                {
                    TrackId = activity.TrackId,
                    Name = activity.Name,
                    ImageUrl = activity.ImageUrl,
                    Description = activity.Description
                };

                _context.Activity.Add(activityEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction("TrackDetails", "Track", new { id = activity.TrackId });
            }

            return View(activity);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsActivity(int id)
        {
            var activityEntity = await _context.Activity
                .Include(a => a.Track)
                .Include(a => a.CarsAvailable)
                .ThenInclude(ca => ca.Cars)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (activityEntity == null)
            {
                return NotFound("Activity not found.");
            }

            var detailsActivityViewModel = new DetailsActivityViewModel
            {
                Id = activityEntity.Id,
                Name = activityEntity.Name,
                Description = activityEntity.Description,
                ImageUrl = activityEntity.ImageUrl,
                Track = activityEntity.Track,
                CarsAvailable = activityEntity.CarsAvailable.Select(ca => new CarsAvailableViewModel
                {
                    CarsId = ca.Cars.Id,
                    CarsName = ca.Cars.Name,
                    CarsDescription = ca.Cars.Description,
                    CarsImageUrl = ca.Cars.ImageUrl
                }).ToList()
            };

            return View(detailsActivityViewModel);
        }


        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditActivity(int id)
        {

            var activity = await _context.Activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            EditActivityViewModel activityView = new EditActivityViewModel()
            {
                Id = id,
                Name = activity.Name,
                Description = activity.Description,
                ImageUrl = activity.ImageUrl,
            };

            return View(activityView);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditActivity(EditActivityViewModel activity)
        {
            var activityEdit = await _context.Activity.FindAsync(activity.Id);

            if (activityEdit == null)
            {
                return NotFound();
            }

            activityEdit.Name = activity.Name;
            activityEdit.Description = activity.Description;
            activityEdit.ImageUrl = activity.ImageUrl;

            if (ModelState.IsValid)
            {
                _context.Update(activityEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction("ActivityDetails", new { id = activity.Id });
            }

            return View(activity);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _context.Activity
                .Include(c => c.CarsAvailable)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (activity == null)
            {
                return NotFound();
            }

            _context.CarsAvailable.RemoveRange(activity.CarsAvailable);
            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();

            return RedirectToAction("ActivityDetails", "Activity", new { id = activity.TrackId });
        }
    }
}
