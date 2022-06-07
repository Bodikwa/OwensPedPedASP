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
    public class CompanyRepository : ICompanyRepository
    {

        private readonly OwensPedPedDBContext _context;

        public CompanyRepository(OwensPedPedDBContext context)
        {
            _context = context;
        }

        public void DeleteCompany(int CompanyId)
        {
            Company company = _context.Companies.Find(CompanyId);
            _context.Companies.Remove(company);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company GetCompanyById(int CompanyId)
        {
            return _context.Companies.Find(CompanyId);
        }

        public void InsertCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public void SaveCompany()
        {
            _context.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
        }
    }
}
