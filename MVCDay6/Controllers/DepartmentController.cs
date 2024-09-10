using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var department = _departmentRepository.GetAll();
        //    //ViewBag.Inst = _context.instructors.ToList();
        //    return View(department);
        //}

        //[HttpPost]
        //public IActionResult Update(Department department)
        //{
        //    var dept = _departmentRepository.Update(department);
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
                _departmentRepository.Add(department);
                return RedirectToAction("Index");
            }
            // ViewBag.Inst = _context.instructors.ToList();
            return View(department);
        }

        //public IActionResult Delete(int id)
        //{
        //    var department = _departmentRepository.GetById(id);
        //    if (department != null)
        //    {
        //        _departmentRepository.Remove(department);
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
