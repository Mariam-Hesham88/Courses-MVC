using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;
using MVCDay6.Models.Entities;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<CourseViewModel> courseViewModels;

            var courses = _unitOfWork.CoursesRepository.GetAll();
            courseViewModels = _mapper.Map<IEnumerable<CourseViewModel>>(courses);
            return View(courseViewModels);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var course = _unitOfWork.CoursesRepository.GetById(id);
            var courseViewModel = _mapper.Map<Course>(course);
            return View(courseViewModel);
        }

        [HttpPost]
        public IActionResult Update(CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(courseViewModel);
                _unitOfWork.CoursesRepository.Update(course);
                return RedirectToAction("Index");
            }
            ViewBag.Instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(courseViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(new CourseViewModel());
        }

        [HttpPost]
        public IActionResult Add(CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(courseViewModel);
                _unitOfWork.CoursesRepository.Add(course);
                return RedirectToAction("Index");
            }
            ViewBag.Instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(courseViewModel);
        }

        public IActionResult Delete(int id)
        {
            var course = _unitOfWork.CoursesRepository.GetById(id);
            if (course == null)
                return NotFound();

            _unitOfWork.CoursesRepository.Delete(course);
            return RedirectToAction("Index");
        }
    }
}
