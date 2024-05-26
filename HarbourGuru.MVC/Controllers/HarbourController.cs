using HarbourGuru.MVC.Repository;
using HarbourGuru.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HarbourGuru.MVC.Controllers
{
    [Route("{countryCodeA2}")]
    public class HarbourController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public HarbourController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            var harbourVM = new HarbourViewModel
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                Harbours = country.Harbours,
                CountryCodeA2 = country.CountryCodeA2 // Ensure this is included
            };

            return View(harbourVM);
        }

        [HttpGet("{harbourCode}")]
        public IActionResult HarbourCards(string countryCodeA2, string harbourCode)
        {
            var country = _unitOfWork.CountryRepository.Get(
                c => c.CountryCodeA2 == countryCodeA2,
                includeProperties: "Harbours.HarbourCards"
            ).FirstOrDefault();

            if (country == null)
            {
                return NotFound();
            }

            var harbour = country.Harbours.FirstOrDefault(h => h.HarbourCode == harbourCode);
            if (harbour == null)
            {
                return NotFound();
            }

            var harbourCardsVM = new HarbourCardViewModel
            {
                HarbourId = harbour.HarbourId,
                HarbourName = harbour.HarbourName,
                HarbourCards = harbour.HarbourCards.ToList()
            };

            return View(harbourCardsVM);
        }
    }
}
