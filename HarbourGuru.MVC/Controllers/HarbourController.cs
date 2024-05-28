using HarbourGuru.MVC.Models;
using HarbourGuru.MVC.Repository;
using HarbourGuru.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HarbourGuru.MVC.Controllers
{
    [Route("{countryCodeA2}")]
    public class HarbourController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<HarbourController> _logger;

        public HarbourController(UnitOfWork unitOfWork, ILogger<HarbourController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index(string countryCodeA2)
        {
            var country = _unitOfWork.CountryRepository.Get(
                c => c.CountryCodeA2 == countryCodeA2,
                includeProperties: "Harbours"
            ).FirstOrDefault();

            if (country == null)
            {
                return NotFound();
            }

            var harbourVM = new HarbourIndexViewModel
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                Harbours = country.Harbours,
                CountryCodeA2 = country.CountryCodeA2
            };

            return View(harbourVM);
        }

        [HttpGet("create")]
        public IActionResult Create(string countryCodeA2)
        {
            var country = _unitOfWork.CountryRepository.Get(
                c => c.CountryCodeA2 == countryCodeA2
            ).FirstOrDefault();

            if (country == null)
            {
                return NotFound();
            }

            var harbour = new HarbourCreateViewModel
            {
                CountryId = country.CountryId
            };

            return View(harbour);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string countryCodeA2, HarbourCreateViewModel harbourVM)
        {
            if (ModelState.IsValid)
            {
                var harbour = new Harbour
                {
                    HarbourCode = harbourVM.HarbourCode,
                    HarbourName = harbourVM.HarbourName,
                    CountryId = harbourVM.CountryId
                };

                _unitOfWork.HarbourRepository.Insert(harbour);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index), new { countryCodeA2 });
            }

            return View(harbourVM);
        }

        [HttpGet("edit/{harbourId}")]
        public IActionResult Edit(string countryCodeA2, int harbourId)
        {
            var harbour = _unitOfWork.HarbourRepository.GetByID(harbourId, "Country");
            if (harbour == null)
            {
                return NotFound();
            }

            var harbourVM = new HarbourEditViewModel
            {
                HarbourId = harbour.HarbourId,
                HarbourCode = harbour.HarbourCode,
                HarbourName = harbour.HarbourName,
                CountryId = harbour.CountryId
            };

            return View(harbourVM);
        }

        [HttpPost("edit/{harbourId}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string countryCodeA2, int harbourId, HarbourEditViewModel harbourVM)
        {
            if (harbourId != harbourVM.HarbourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var harbour = new Harbour
                {
                    HarbourId = harbourVM.HarbourId,
                    HarbourCode = harbourVM.HarbourCode,
                    HarbourName = harbourVM.HarbourName,
                    CountryId = harbourVM.CountryId
                };

                try
                {
                    _unitOfWork.HarbourRepository.Update(harbour);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.HarbourRepository.GetByID(harbourId) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index), new { countryCodeA2 });
            }

            return View(harbourVM);
        }

        [HttpGet("delete/{harbourId}")]
        public IActionResult Delete(string countryCodeA2, int harbourId)
        {
            var harbour = _unitOfWork.HarbourRepository.GetByID(harbourId);
            if (harbour == null)
            {
                return NotFound();
            }

            var harbourVM = new HarbourDeleteViewModel
            {
                HarbourId = harbour.HarbourId,
                HarbourCode = harbour.HarbourCode,
                HarbourName = harbour.HarbourName
            };

            return View(harbourVM);
        }

        [HttpPost("delete/{harbourId}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string countryCodeA2, int harbourId)
        {
            var harbour = _unitOfWork.HarbourRepository.GetByID(harbourId);
            if (harbour != null)
            {
                _unitOfWork.HarbourRepository.Delete(harbour);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index), new { countryCodeA2 });
        }

        [HttpGet("{harbourCode}")]
        public IActionResult Details(string countryCodeA2, string harbourCode)
        {
            var harbour = _unitOfWork.HarbourRepository.Get(
                h => h.HarbourCode == harbourCode && h.Country.CountryCodeA2 == countryCodeA2,
                includeProperties: "Country,HarbourCards"
            ).FirstOrDefault();

            if (harbour == null)
            {
                return NotFound();
            }

            var harbourDetailsVM = new HarbourDetailsViewModel
            {
                HarbourId = harbour.HarbourId,
                HarbourCode = harbour.HarbourCode,
                HarbourName = harbour.HarbourName,
                CountryName = harbour.Country.CountryName,
                CountryCodeA2 = harbour.Country.CountryCodeA2,
                HarbourCards = harbour.HarbourCards.ToList()
            };

            return View(harbourDetailsVM);
        }
    }
}
