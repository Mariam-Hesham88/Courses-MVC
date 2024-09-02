using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;

namespace MVCDay6.Controllers
{
    public class DepartmentController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            List<Department> department = _context.departments.ToList();
            return View(department);
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _context.departments.FirstOrDefault(d => d.Id == id);
            ViewBag.Inst = _context.instructors.ToList();
            return View(department);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            var dept = _context.departments.Update(department);
            _context.SaveChanges();
            ViewBag.Inst = _context.instructors.ToList();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Inst = _context.instructors.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inst = _context.instructors.ToList();
            return View("Add", department);
        }

        //public IActionResult Delete(int id)
        //{
        //    var department = _context.departments.FirstOrDefault(i => i.Id == id);
        //    if (department != null)
        //    {
        //        _context.departments.Remove(department);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
