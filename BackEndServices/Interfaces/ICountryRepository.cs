using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndServices.Interfaces
{
   public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int Countryid);
        void InsertCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int CountryId);
        void SaveCountry();

    }
}
