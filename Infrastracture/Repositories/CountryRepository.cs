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
    public class CountryRepository : ICountryRepository
    {

        private readonly OwensPedPedDBContext _context;

        public CountryRepository(OwensPedPedDBContext context)
        {
            _context = context;
        }

        public void DeleteCountry(int CountryId)
        {
            Country country = _context.Countries.Find(CountryId);
            _context.Countries.Remove(country);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int Countryid)
        {
            return _context.Countries.Find(Countryid);
        }

        public void InsertCountry(Country country)
        {
            _context.Countries.Add(country);
        }

        public void SaveCountry()
        {
            _context.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
        }
    }
}
