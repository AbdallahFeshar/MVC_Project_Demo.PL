using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVC_Project_Demo.BLL.Interfaces;
using MVC_Project_Demo.BLL.Repositorys;
using MVC_Project_Demo.DAL.Models;
using System;

namespace MVC_Project_Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWebHostEnvironment _env;

        //public IWebHostEnvironment Env { get; }

        public DepartmentController(IDepartmentRepository departmentRepository, IWebHostEnvironment env)
        {
            _departmentRepository = departmentRepository;
            _env = env;
        }


        public IActionResult Index()
        {
            var Department = _departmentRepository.GetAll();
            return View(Department);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepository.Add(department);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departmentRepository.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(ViewName, department);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (!id.HasValue)
            //{
            //    return BadRequest();
            //}
            //var department = _departmentRepository.GetById(id.Value);
            //if (department == null)
            //{
            //    return NotFound();
            //}
            //return View(department);
            return Details(id,"Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit([FromRoute]int id,Department department)
        {
            if (id != department.Id) 
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            try
            {
                _departmentRepository.Update(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if(_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "AnError Occur When Update");
                }
                return View(department);
            }
         

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id,"Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            try
            {
                _departmentRepository.Delete(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "AnError Occur When Update");
                }
                return View(department);
            }

        }

    }
}

