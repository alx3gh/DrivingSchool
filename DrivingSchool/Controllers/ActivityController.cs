using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
