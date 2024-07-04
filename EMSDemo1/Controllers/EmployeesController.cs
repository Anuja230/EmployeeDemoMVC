using EMSDemo1.Data;
using EMSDemo1.Data.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace EMSDemo1.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context= context;       
 }
        public IActionResult Index()
        {
            var empdata = _context.Employees.ToList();
            return View(empdata);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var empdata = _context.Employees.Find(id);
            return View(empdata);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            var empdata = _context.Employees.Find(id);
            return View(empdata);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var empdata = _context.Employees.Find(id);
            return View(empdata);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var empdata = _context.Employees.Find(id);
            _context.Employees.Remove(empdata);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
