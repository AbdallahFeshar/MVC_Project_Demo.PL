using Microsoft.EntityFrameworkCore;
using MVC_Project_Demo.DAL.Data.Configurations;
using MVC_Project_Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project_Demo.DAL.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        { 

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=. ; Database=project_MVC ; trusted_connection=true ; MultipleActiveResultSets=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Department>Departments{ get;set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
