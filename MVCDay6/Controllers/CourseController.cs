using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var courses = _unitOfWork.CoursesRepository.GetAll();
            return View(courses);
        }

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var course = _unitOfWork.CoursesRepository.GetById(id);
        //    return View(course);
        //}

        //[HttpPost]
        //public IActionResult Update(Course course)
        //{
        //    _unitOfWork.CoursesRepository.Update(course);
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
                _unitOfWork.CoursesRepository.Add(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        //public IActionResult Delete(int id)
        //{
        //    var course = _unitOfWork.CoursesRepository.GetById(id);
        //    if (course != null)
        //    {
        //        _unitOfWork.CoursesRepository.Delete(course);
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
