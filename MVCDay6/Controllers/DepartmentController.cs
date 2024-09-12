using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var department = _unitOfWork.DepartmentRepository.GetAll();
        //    //ViewBag.Inst = _context.instructors.ToList();
        //    return View(department);
        //}

        //[HttpPost]
        //public IActionResult Update(Department department)
        //{
        //    var dept = _unitOfWork.DepartmentRepository.Update(department);
        //    //ViewBag.Inst = _context.instructors.ToList();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.Inst = _context.instructors.ToList();
            return View(new Department());
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DepartmentRepository.Add(department);
                return RedirectToAction("Index");
            }
            // ViewBag.Inst = _context.instructors.ToList();
            return View(department);
        }

        //public IActionResult Delete(int id)
        //{
        //    var department = _unitOfWork.DepartmentRepository.GetById(id);
        //    if (department != null)
        //    {
        //        _departmentRepository.Remove(department);
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
