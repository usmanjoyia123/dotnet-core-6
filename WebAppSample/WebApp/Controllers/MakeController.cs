using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MakeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MakeController(ApplicationDbContext context)
        {
            _context= context;  
        }

        
        public IActionResult Index()
        {
            IEnumerable<Make> list = _context.Makes.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Make obj)
        {
            var alreadyExist = _context.Makes.FirstOrDefault(x => x.Name ==obj.Name);
            if (alreadyExist != null)
            {
                ModelState.AddModelError("CustomError","Make Already Exist");
            }
            if (ModelState.IsValid)
            {

                _context.Makes.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index"); //View();
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Makes.First(x => x.Id == id); // try to add exception handling here

            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Make obj)
        {
            var alreadyExist = _context.Makes.FirstOrDefault(x => x.Name == obj.Name);
            if (alreadyExist != null)
            {
                ModelState.AddModelError("CustomError", "Make Already Exist");
            }
            if (ModelState.IsValid)
            {

                _context.Makes.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index"); //View();
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Makes.First(x => x.Id == id); // try to add exception handling here
            if (ModelState.IsValid)
            {

                _context.Makes.Remove(data);
                _context.SaveChanges();
                //return RedirectToAction("Index"); //View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            var data = _context.Makes.First(x=> x.Id == id);
            return View(data);
        }
    }
}
