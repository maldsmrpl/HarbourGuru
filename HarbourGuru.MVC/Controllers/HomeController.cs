using HarbourGuru.MVC.Models;
using HarbourGuru.MVC.Repository;
using HarbourGuru.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HarbourGuru.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        [Route("")]
        public IActionResult Index()
        {
            var countries = _unitOfWork.CountryRepository.Get();
            var sortedCountries = countries.OrderBy(c => c.CountryName).ToList();

            var countryVM = new HomeIndexViewModel
            {
                Countries = sortedCountries
            };

            return View(countryVM);
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CountryRepository.Insert(country);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var country = _unitOfWork.CountryRepository.GetByID(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Country country)
        {
            if (id != country.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CountryRepository.Update(country);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.CountryRepository.GetByID(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index", "Home");
            }
            return View(country);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var country = _unitOfWork.CountryRepository.GetByID(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var country = _unitOfWork.CountryRepository.GetByID(id);
            if (country != null)
            {
                _unitOfWork.CountryRepository.Delete(country);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
