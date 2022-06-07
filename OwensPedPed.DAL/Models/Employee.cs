using System;
using System.Collections.Generic;

#nullable disable

namespace OwensPedPed.DAL.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeContactNumber { get; set; }
        public string EmployeeEmailNumber { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public int ProvenceId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }
        public virtual Provence Provence { get; set; }
    }
}
