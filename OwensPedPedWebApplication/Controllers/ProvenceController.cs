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
    public class ProvenceController : Controller
    {



        private readonly IProvenceRepository _provenceRepository;
        private readonly ICountryRepository _countryRepository;

        public ProvenceController(IProvenceRepository provenceRepository, ICountryRepository countryRepository)
        {
            _provenceRepository = provenceRepository;
            _countryRepository = countryRepository;
        }
        // GET: ProvenceController
        public ActionResult Index()
        {
            return View(_provenceRepository.GetAllProvences());
        }

        // GET: ProvenceController/Details/5
        public ActionResult Details(int id)
        {
            return View(_provenceRepository.GetProvenceById(id));
        }

        // GET: ProvenceController/Create
        public ActionResult Create()
        {
            GetCountryViewbag();
            return View();
        }

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

        // POST: ProvenceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Provence provence )
        {
            try
            {
                _provenceRepository.InsertProvence(provence);
                _provenceRepository.SaveProvence();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                GetCountryViewbag();
                return View();
            }
        }

        // GET: ProvenceController/Edit/5
        public ActionResult Edit(int id)
        {
            GetCountryViewbag();
            return View(_provenceRepository.GetProvenceById(id));
        }

        // POST: ProvenceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Provence provence)
        {
            try
            {
                _provenceRepository.UpdateProvence(provence);
                _provenceRepository.SaveProvence();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                GetCountryViewbag();
                return View();
            }
        }

        // GET: ProvenceController/Delete/5
        public ActionResult Delete(int id)
        {
            GetCountryViewbag();
            return View(_provenceRepository.GetProvenceById(id));
        }

        // POST: ProvenceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Provence provence)
        {
            try
            {
                
                _provenceRepository.DeleteProvence(provence.ProvenceId);
                _provenceRepository.SaveProvence();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                GetCountryViewbag();
                return View();
            }
        }
    }
}
