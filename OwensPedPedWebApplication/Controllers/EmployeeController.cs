using BackEndServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwensPedPedWebApplication.Controllers
{
    public class EmployeeController : Controller
    {

       
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
            // GET: EmployeeController
            public ActionResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_employeeRepository.GetEmployeeById(id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Employee employee)
        {
            try
            {
                _employeeRepository.InsertEmployee(employee);
                _employeeRepository.SaveEmployee();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_employeeRepository.GetEmployeeById(id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Employee employee)
        {
            try
            {
                _employeeRepository.UpdateEmployee(employee);
                _employeeRepository.SaveEmployee();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_employeeRepository.GetEmployeeById(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Employee employee)
        {
            try
            {
                _employeeRepository.DeleteEmployee(employee.EmployeeId);
                _employeeRepository.SaveEmployee();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
