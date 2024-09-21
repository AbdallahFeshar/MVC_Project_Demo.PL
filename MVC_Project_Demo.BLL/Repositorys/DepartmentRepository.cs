
using Microsoft.EntityFrameworkCore;
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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int Add(Department department)
        {
           _appDbContext.Add(department);
            return _appDbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            _appDbContext.Remove(department);
            return _appDbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _appDbContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            var department = _appDbContext.Departments.Find(id);
            return department;
        }

        public int Update(Department department)
        {
            _appDbContext.Update(department);
            return _appDbContext.SaveChanges();
        }
    }
}
