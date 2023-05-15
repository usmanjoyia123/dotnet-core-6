using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class NewSampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
