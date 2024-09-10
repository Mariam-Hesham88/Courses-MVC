using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICoursesRepository _coursesRepository;

        public CourseController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public IActionResult Index()
        {
            var courses = _coursesRepository.GetAll();
            return View(courses);
        }
        
        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var course = _coursesRepository.GetById(id);
        //    return View(course);
        //}

        //[HttpPost]
        //public IActionResult Update(Course course)
        //{
        //    _coursesRepository.Update(course);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Course());
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                _coursesRepository.Add(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        //public IActionResult Delete(int id)
        //{
        //    var course = _coursesRepository.GetById(id);
        //    if (course != null)
        //    {
        //        _coursesRepository.Delete(course);
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
