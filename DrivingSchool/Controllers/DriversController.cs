using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class DriversController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
