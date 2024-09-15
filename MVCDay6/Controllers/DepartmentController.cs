using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;
using MVCDay6.Models.Entities;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapping)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapping;
        }

        public IActionResult Index(String SearchValue)
        {
            IEnumerable<Department> departments;
            IEnumerable<DepartmentViewModel> departmentViewModel;

            if (string.IsNullOrEmpty(SearchValue))
            {
                departments = _unitOfWork.DepartmentRepository.GetAll();
                departmentViewModel = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            }
            else
            {
                departments = _unitOfWork.DepartmentRepository.Search(SearchValue);
                departmentViewModel = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            }
            return View(departmentViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
                return NotFound();

            var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);
            ViewBag.Instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Update(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var departmentToUpdate = _unitOfWork.DepartmentRepository.GetById(departmentViewModel.Id); // Ensure consistency

                if (departmentToUpdate == null)
                    return NotFound();

                _mapper.Map(departmentViewModel, departmentToUpdate); // Update existing department
                _unitOfWork.DepartmentRepository.Update(departmentToUpdate);
                return RedirectToAction("Index");
            }

            ViewBag.Instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(departmentViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(new DepartmentViewModel());
        }

        [HttpPost]
        public IActionResult Add(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var dpartment = _mapper.Map<Department>(departmentViewModel);
                _unitOfWork.DepartmentRepository.Add(dpartment);
                return RedirectToAction("Index");
            }
            ViewBag.Instructors = _unitOfWork.InstructorRepository.GetAll();
            return View(departmentViewModel);
        }

        public IActionResult Delete(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
                return NotFound();

            _unitOfWork.DepartmentRepository.Delete(department);
            return RedirectToAction("Index");
        }
    }
}
