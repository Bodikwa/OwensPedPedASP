using BackEndServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly OwensPedPedDBContext _context;

        public EmployeeRepository(OwensPedPedDBContext context)
        {
            _context = context;
        }
        public void DeleteEmployee(int EmployeeId)
        {
            Employee employee = _context.Employees.Find(EmployeeId);
            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int EmployeeId)
        {

            return _context.Employees.Find(EmployeeId);
        }

        public void InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void SaveEmployee()
        {
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
    }
}
