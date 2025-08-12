using DrivingSchool.Data;
using DrivingSchool.Models;
using DrivingSchool.ViewModels.ActivityVM;
using DrivingSchool.ViewModels.TracksVM;
using DrivingSchool.ViewModels.DriversVM; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchool.Controllers
{
    [AutoValidateAntiforgeryToken]

    public class TrackController : Controller
    {
        private readonly DrivingSchoolDbContext _context;

        public TrackController(DrivingSchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var track = await _context.Track
                .Select(t => new TrackViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Location = t.Location,
                    ImageUrl = t.ImageUrl
                })
                .ToListAsync();

            return View(track);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateTrack()
        {
            return View(new CreateTrackViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateTrack(CreateTrackViewModel model)
        {
            if (ModelState.IsValid)
            {
                var track = new Track
                {
                    Name = model.Name,
                    Location = model.Location,
                    ImageUrl = model.ImageUrl,
                    Description = model.Description
                };

                _context.Track.Add(track);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> TrackDetails(int id)
        {
            var track = await _context.Track
                .Include(t => t.Activity)
                .Include(t => t.Drivers)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (track == null)
            {
                return NotFound();
            }

            var viewModel = new DetailsTrackViewModel
            {
                Id = track.Id,
                Name = track.Name,
                Location = track.Location,
                Description = track.Description,
                ImageUrl = track.ImageUrl,
                Activity = track.Activity.Select(activity => new ActivityViewModel
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    ImageUrl = activity.ImageUrl
                }).ToList(),

                Drivers = track.Drivers.Select(drivers => new DriversViewModel
                {
                    Id = drivers.Id,
                    Name = drivers.Name,
                    ImageUrl = drivers.ImageUrl
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var track = await _context.Track.FindAsync(id);

            if (track == null)
            {
                return NotFound();
            }

            _context.Track.Remove(track);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditTrack(int id)
        {
            var track = await _context.Track.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            var model = new EditTrackViewModel
            {
                Id = track.Id,
                Name = track.Name,
                Location = track.Location,
                ImageUrl = track.ImageUrl,
                Description = track.Description
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditTrack(EditTrackViewModel model)
        {
            if (ModelState.IsValid)
            {
                var track = await _context.Track.FindAsync(model.Id);
                if (track == null)
                {
                    return NotFound();
                }

                track.Name = model.Name;
                track.Location = model.Location;
                track.ImageUrl = model.ImageUrl;
                track.Description = model.Description;

                _context.Track.Update(track);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
