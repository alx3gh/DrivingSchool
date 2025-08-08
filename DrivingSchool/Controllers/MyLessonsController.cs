using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class MyLessonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
