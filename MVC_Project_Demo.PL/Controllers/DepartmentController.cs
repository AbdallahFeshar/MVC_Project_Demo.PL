using Microsoft.AspNetCore.Mvc;
using MVC_Project_Demo.BLL.Interfaces;
using MVC_Project_Demo.BLL.Repositorys;

namespace MVC_Project_Demo.PL.Controllers
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
            _departmentRepository.GetAll();
            return View();
        }
    }
}
