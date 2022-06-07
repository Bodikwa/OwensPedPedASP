using BackEndServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwensPedPedWebApplication.Controllers
{
    public class ProvenceController : Controller
    {



        private readonly IProvenceRepository _provenceRepository;


        public ProvenceController(IProvenceRepository provenceRepository)
        {
            _provenceRepository = provenceRepository;
        }
        // GET: ProvenceController
        public ActionResult Index()
        {
            return View(_provenceRepository.GetAllProvences());
        }

        // GET: ProvenceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProvenceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvenceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProvenceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProvenceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProvenceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvenceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
