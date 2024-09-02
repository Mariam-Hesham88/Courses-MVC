using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;

namespace MVCDay6.Controllers
{
    public class CourseController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            List<Course> courses = _context.courses.ToList();
            return View(courses);
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            var course = _context.courses.FirstOrDefault(x => x.Id == id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Update(Course course)
        {
            var curs = _context.courses.Update(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add", course);
        }

        //public IActionResult Delete(int id)
        //{
        //    var course = _context.courses.FirstOrDefault(i => i.Id == id);
        //    if (course != null)
        //    {
        //        _context.courses.Remove(course);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
