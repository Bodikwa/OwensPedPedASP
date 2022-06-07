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


        public CompanyController(ICompanyRepository companyRepository, ICountryRepository countryRepository)
        {
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
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

        private void GetProvenceViewbag()
        {
            var countries = _countryRepository.GetAllCountries().OrderBy(x => x.CountryName);

            List<SelectListItem> countryOption = new List<SelectListItem>();

            foreach (var c in countries)
            {
                countryOption.Add(new SelectListItem(c.CountryName, c.CountryId.ToString()));
            }

            ViewBag.countryViewbag = countryOption;
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
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
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
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
                return View();
            }
        }
    }
}
