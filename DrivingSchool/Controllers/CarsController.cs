using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
