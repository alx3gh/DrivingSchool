using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class LessonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
