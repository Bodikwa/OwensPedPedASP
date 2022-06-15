using BackEndServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwensPedPedWebApplication.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvenceRepository _provenceRepository;


        public CompanyController(ICompanyRepository companyRepository,
            ICountryRepository countryRepository, IProvenceRepository provenceRepository)
        {
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
            _provenceRepository = provenceRepository;

        }
        // GET: CompanyController
        public ActionResult Index()
        {
            return View( _companyRepository.GetAllCompanies());
        }

        // GET: CompanyController/Details/5
        public ActionResult Details(int id)
        {
            return View(_companyRepository.GetCompanyById(id));
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            GetProvenceViewbag();
            GetCountryViewbag();
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Company company)
        {
            try
            {
                _companyRepository.InsertCompany(company);
                _companyRepository.SaveCompany();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //adding the country drop down list  inside the company
        private void GetCountryViewbag()
        {
            var countries = _countryRepository.GetAllCountries().OrderBy(x => x.CountryName);

            List<SelectListItem> countryOption = new List<SelectListItem>();

            foreach (var c in countries)
            {
                countryOption.Add(new SelectListItem(c.CountryName, c.CountryId.ToString()));
            }

            ViewBag.countryViewbag = countryOption;
        }

        //Ading the provence drop down list inside the company
        private void GetProvenceViewbag()
        {
            var countries = _provenceRepository.GetAllProvences().OrderBy(x => x.ProvenceName);

            List<SelectListItem> provenceOption = new List<SelectListItem>();

            foreach (var c in countries)
            {
                provenceOption.Add(new SelectListItem(c.ProvenceName, c.ProvenceId.ToString()));
            }

            ViewBag.countryViewbag = provenceOption;
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)

        {
            GetProvenceViewbag();
            GetCountryViewbag();
            return View(_companyRepository.GetCompanyById(id));
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Company company)
        {
            try
            {
                _companyRepository.UpdateCompany(company);
                _companyRepository.SaveCompany();
;                return RedirectToAction(nameof(Index));
            }
            catch
            {
                GetProvenceViewbag();
                GetCountryViewbag(); 
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            GetProvenceViewbag();
            GetCountryViewbag(); 
            return View(_companyRepository.GetCompanyById(id));
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Company company)
        {
            try
            {
                _companyRepository.DeleteCompany(company.CompanyId);
                _companyRepository.SaveCompany();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                GetProvenceViewbag();
                GetCountryViewbag();
                return View();
            }
        }
    }
}
