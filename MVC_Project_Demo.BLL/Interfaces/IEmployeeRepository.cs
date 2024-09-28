using MVC_Project_Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project_Demo.BLL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        int Add(Employee Employee);
        int Update(Employee Employee);
        int Delete(Employee Employee);

    }
}
