using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDay6.Models;

namespace MVCDay6.Controllers
{
    public class InstructorController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            List<Instructor> instructors = _context.instructors.ToList();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var inst = _context.instructors.FirstOrDefault(x => x.Id == id);
            return PartialView("Details", inst);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var instructor = _context.instructors.FirstOrDefault(x => x.Id == id);
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Update(Instructor instructor)
        {
            if (ModelState.IsValid) 
            {
                var inst = _context.instructors.Update(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Update");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.instructors.Add(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add", instructor);
        }

        public IActionResult Delete(int id)
        {
            var instructor = _context.instructors.FirstOrDefault(i => i.Id == id);
            if (instructor != null)
            {
                _context.instructors.Remove(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult CheckSalary(double Salary, int DeptId)
        {
            if (Salary > 1000 && DeptId == 1)
            {
                return Json(true);
            }
            else if (Salary > 2000 && DeptId == 2)
            {
                return Json(true);

            }
            else if (Salary > 3000 && DeptId == 3)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
