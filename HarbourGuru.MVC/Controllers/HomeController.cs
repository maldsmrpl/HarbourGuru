using HarbourGuru.MVC.Models;
using HarbourGuru.MVC.Repository;
using HarbourGuru.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            if (_unitOfWork == null) 
                return View("Error", "Unit of Work is not initialized.");

            if (_unitOfWork.CountryRepository == null) 
                return View("Error", "Country Repository is not initialized.");

            var countries = _unitOfWork.CountryRepository.Get();

            if (countries == null)
                return View("Error", "No countries found.");

            var sortedCountries = countries.OrderBy(c => c.CountryName).ToList();

            if (!sortedCountries.Any())
                return View("NoCountries");

            var countryVM = new CountryViewModel
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
