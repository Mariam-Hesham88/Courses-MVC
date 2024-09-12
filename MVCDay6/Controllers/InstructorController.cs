using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;
using MVCDay6.Repo.Repositories;

namespace MVCDay6.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstructorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var inst = _unitOfWork.InstructorRepository.GetById(id);
            return View(inst);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var instructor = _unitOfWork.InstructorRepository.GetById(id);
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Update(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.InstructorRepository.Update(instructor);
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
                _unitOfWork.InstructorRepository.Add(instructor);
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public IActionResult Delete(int id)
        {
            var instructor = _unitOfWork.InstructorRepository.GetById(id);

            if (instructor is null)
                return NotFound();

            _unitOfWork.InstructorRepository.Delete(instructor);
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
