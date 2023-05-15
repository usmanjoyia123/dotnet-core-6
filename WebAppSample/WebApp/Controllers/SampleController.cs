using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
