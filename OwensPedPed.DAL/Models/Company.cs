using System;
using System.Collections.Generic;

#nullable disable

namespace OwensPedPed.DAL.Models
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CountryId { get; set; }
        public int ProvenceId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Provence Provence { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
