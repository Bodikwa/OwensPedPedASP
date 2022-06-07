using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndServices.Interfaces
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int EmployeeId);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int EmployeeId);
        void SaveEmployee();

    }
}
