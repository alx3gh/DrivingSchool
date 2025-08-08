using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
