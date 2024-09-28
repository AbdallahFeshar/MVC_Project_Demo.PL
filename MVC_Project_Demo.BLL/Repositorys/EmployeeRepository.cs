using MVC_Project_Demo.BLL.Interfaces;
using MVC_Project_Demo.DAL.Data;
using MVC_Project_Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project_Demo.BLL.Repositorys
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int Add(Employee Employee)
        {
            _appDbContext.Add(Employee);
            return _appDbContext.SaveChanges();
        }

        public int Delete(Employee Employee)
        {
            _appDbContext.Remove(Employee);
            return _appDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _appDbContext.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            var Employee = _appDbContext.Employees.Find(id);
            return Employee;
        }

        public int Update(Employee Employee)
        {
            _appDbContext.Update(Employee);
            return _appDbContext.SaveChanges();
        }
    }
}
