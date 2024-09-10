using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;
using MVCDay6.Repo.Repositories;

namespace MVCDay6.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public IActionResult Index()
        {
            var instructors = _instructorRepository.GetAll();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var inst = _instructorRepository.GetById(id);
            return View(inst);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Update(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Update(instructor);
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Instructor());
        }

        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Add(instructor);
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public IActionResult Delete(int id)
        {
            var instructor = _instructorRepository.GetById(id);

            if (instructor is null)
                return NotFound();

            _instructorRepository.Delete(instructor);
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
