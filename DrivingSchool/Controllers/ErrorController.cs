using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
