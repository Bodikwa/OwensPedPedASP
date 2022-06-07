using System;
using System.Collections.Generic;

#nullable disable

namespace OwensPedPed.DAL.Models
{
    public partial class Provence
    {
        public Provence()
        {
            Companies = new HashSet<Company>();
            Employees = new HashSet<Employee>();
        }

        public int ProvenceId { get; set; }
        public string ProvenceName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
