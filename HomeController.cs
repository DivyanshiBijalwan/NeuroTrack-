using Microsoft.AspNetCore.Mvc;

namespace NeuroTrack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
