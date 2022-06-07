using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndServices.Interfaces
{
   public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int CompanyId);
        void InsertCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int CompanyId);
        void SaveCompany();
    }
}
