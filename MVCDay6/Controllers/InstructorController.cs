using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDay6.Models;
using MVCDay6.Models.Entities;
using MVCDay6.Repo.Interfaces;
using MVCDay6.Repo.Repositories;

namespace MVCDay6.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapping;

        public InstructorController(IUnitOfWork unitOfWork, IMapper mapping)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
        }

        public IActionResult Index(string SearchValue ="")
        {
            IEnumerable<Instructor> instructors;
            IEnumerable<InstructorViewModel> instructorsViewModel;

            if (string.IsNullOrEmpty(SearchValue))
            {
                instructors = _unitOfWork.InstructorRepository.GetAll();
                instructorsViewModel = _mapping.Map<IEnumerable<InstructorViewModel>>(instructors);
            }
            else
            {
                instructors = _unitOfWork.InstructorRepository.Search(SearchValue);
                instructorsViewModel = _mapping.Map<IEnumerable<InstructorViewModel>>(instructors);
            }
            return View(instructorsViewModel);
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
            if (instructor == null)
                return NotFound();

            var instructorViewModel = _mapping.Map<InstructorViewModel>(instructor);
            return View(instructorViewModel);
        }

        [HttpPost]
        public IActionResult Update(InstructorViewModel instructorViewModel)
        {
            if (ModelState.IsValid)
            {
                var instructor = _unitOfWork.InstructorRepository.GetById(instructorViewModel.Id);
                if (instructor == null)
                    return NotFound();

                _mapping.Map(instructorViewModel, instructor);
                _unitOfWork.InstructorRepository.Update(instructor);
                return RedirectToAction("Index");
            }
            return View(instructorViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new InstructorViewModel());
        }

        [HttpPost]
        public IActionResult Add(InstructorViewModel instructorViewModel)
        {
            if (ModelState.IsValid)
            {
                var instructor = _mapping.Map<Instructor>(instructorViewModel);
                _unitOfWork.InstructorRepository.Add(instructor);
                return RedirectToAction("Index");
            }
            return View(instructorViewModel);
        }

        public IActionResult Delete(int id)
        {
            var istructor = _unitOfWork.InstructorRepository.GetById(id);
            if (istructor == null)
                return NotFound(); 

            _unitOfWork.InstructorRepository.Delete(istructor);
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
