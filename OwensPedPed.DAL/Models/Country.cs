using System;
using System.Collections.Generic;

#nullable disable

namespace OwensPedPed.DAL.Models
{
    public partial class Country
    {
        public Country()
        {
            Companies = new HashSet<Company>();
            Employees = new HashSet<Employee>();
            Provences = new HashSet<Provence>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Provence> Provences { get; set; }
    }
}
