using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            IEnumerable<Car> List = _context.Cars.ToList();
            return View(List);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var makedata = _context.Makes.Select(data => new { data.Id, data.Name });
            foreach (var item in makedata)
            {

                Console.WriteLine(item);
            }
          //  ViewBag["Data"] = makedata;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car obj)
        {
            return View();
        }
    }
}
