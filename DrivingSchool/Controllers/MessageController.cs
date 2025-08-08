using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
