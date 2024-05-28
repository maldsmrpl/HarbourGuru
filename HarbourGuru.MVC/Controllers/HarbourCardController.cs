﻿using HarbourGuru.MVC.Models;
using HarbourGuru.MVC.Repository;
using HarbourGuru.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HarbourGuru.MVC.Controllers
{
    [Route("{countryCodeA2}/{harbourCode}")]
    public class HarbourCardController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<HarbourCardController> _logger;

        public HarbourCardController(UnitOfWork unitOfWork, ILogger<HarbourCardController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("add")]
        public IActionResult Create(string countryCodeA2, string harbourCode)
        {
            var harbour = _unitOfWork.HarbourRepository.Get(
                h => h.HarbourCode == harbourCode && h.Country.CountryCodeA2 == countryCodeA2,
                includeProperties: "Country"
            ).FirstOrDefault();

            if (harbour == null)
            {
                return NotFound();
            }

            var categories = _unitOfWork.HarbourCardCategoryRepository.Get().ToList();

            var harbourCardVM = new HarbourCardCreateViewModel
            {
                HarbourId = harbour.HarbourId,
                Categories = categories
            };

            return View(harbourCardVM);
        }

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string countryCodeA2, string harbourCode, HarbourCardCreateViewModel harbourCardVM)
        {
            if (ModelState.IsValid)
            {
                var harbourCard = new HarbourCard
                {
                    Name = harbourCardVM.Name,
                    Description = harbourCardVM.Description,
                    Address = harbourCardVM.Address,
                    Email = harbourCardVM.Email,
                    Website = harbourCardVM.Website,
                    HarbourId = harbourCardVM.HarbourId,
                    HarbourCardCategoryId = harbourCardVM.HarbourCardCategoryId
                };

                foreach (var phoneVM in harbourCardVM.Phones)
                {
                    var phone = new HarbourCardPhone
                    {
                        HarbourCardPhoneNumber = phoneVM.HarbourCardPhoneNumber,
                        HarbourCardPhoneDescription = phoneVM.HarbourCardPhoneDescription
                    };
                    harbourCard.Phones.Add(phone);
                }

                _unitOfWork.HarbourCardRepository.Insert(harbourCard);
                _unitOfWork.Save();
                return RedirectToAction("Details", "Harbour", new { countryCodeA2, harbourCode });
            }

            harbourCardVM.Categories = _unitOfWork.HarbourCardCategoryRepository.Get().ToList();

            return View(harbourCardVM);
        }

        [HttpGet("edit/{harbourCardId}")]
        public IActionResult Edit(string countryCodeA2, string harbourCode, int harbourCardId)
        {
            var harbourCard = _unitOfWork.HarbourCardRepository.GetByID(harbourCardId, "Harbour,Phones");
            if (harbourCard == null || harbourCard.Harbour.HarbourCode != harbourCode)
            {
                return NotFound();
            }

            var categories = _unitOfWork.HarbourCardCategoryRepository.Get().ToList();

            var harbourCardVM = new HarbourCardEditViewModel
            {
                HarbourCardId = harbourCard.HarbourCardId,
                Name = harbourCard.Name,
                Description = harbourCard.Description,
                Address = harbourCard.Address,
                Email = harbourCard.Email,
                Website = harbourCard.Website,
                HarbourId = harbourCard.HarbourId,
                HarbourCardCategoryId = harbourCard.HarbourCardCategoryId,
                Categories = categories,
                Phones = harbourCard.Phones.Select(p => new HarbourCardPhoneViewModel
                {
                    HarbourCardPhoneNumber = p.HarbourCardPhoneNumber,
                    HarbourCardPhoneDescription = p.HarbourCardPhoneDescription
                }).ToList()
            };

            ViewData["countryCodeA2"] = countryCodeA2;
            ViewData["harbourCode"] = harbourCode;

            return View(harbourCardVM);
        }

        [HttpPost("edit/{harbourCardId}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string countryCodeA2, string harbourCode, int harbourCardId, HarbourCardEditViewModel harbourCardVM)
        {
            if (harbourCardId != harbourCardVM.HarbourCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var harbourCard = new HarbourCard
                {
                    HarbourCardId = harbourCardVM.HarbourCardId,
                    Name = harbourCardVM.Name,
                    Description = harbourCardVM.Description,
                    Address = harbourCardVM.Address,
                    Email = harbourCardVM.Email,
                    Website = harbourCardVM.Website,
                    HarbourId = harbourCardVM.HarbourId,
                    HarbourCardCategoryId = harbourCardVM.HarbourCardCategoryId
                };

                foreach (var phoneVM in harbourCardVM.Phones)
                {
                    var phone = new HarbourCardPhone
                    {
                        HarbourCardPhoneNumber = phoneVM.HarbourCardPhoneNumber,
                        HarbourCardPhoneDescription = phoneVM.HarbourCardPhoneDescription
                    };
                    harbourCard.Phones.Add(phone);
                }

                try
                {
                    _unitOfWork.HarbourCardRepository.Update(harbourCard);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.HarbourCardRepository.GetByID(harbourCardId) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Details", "Harbour", new { countryCodeA2, harbourCode });
            }

            // Repopulate the Categories list
            harbourCardVM.Categories = _unitOfWork.HarbourCardCategoryRepository.Get().ToList();

            return View(harbourCardVM);
        }

        [HttpGet("delete/{harbourCardId}")]
        public IActionResult Delete(string countryCodeA2, string harbourCode, int harbourCardId)
        {
            var harbourCard = _unitOfWork.HarbourCardRepository.GetByID(harbourCardId);
            if (harbourCard == null)
            {
                return NotFound();
            }

            var harbourCardVM = new HarbourCardDeleteViewModel
            {
                HarbourCardId = harbourCard.HarbourCardId,
                Name = harbourCard.Name,
                Description = harbourCard.Description,
                Address = harbourCard.Address,
                Email = harbourCard.Email,
                Website = harbourCard.Website
            };

            ViewData["countryCodeA2"] = countryCodeA2;
            ViewData["harbourCode"] = harbourCode;

            return View(harbourCardVM);
        }

        [HttpPost("delete/{harbourCardId}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string countryCodeA2, string harbourCode, int harbourCardId)
        {
            var harbourCard = _unitOfWork.HarbourCardRepository.GetByID(harbourCardId);
            if (harbourCard != null)
            {
                _unitOfWork.HarbourCardRepository.Delete(harbourCard);
                _unitOfWork.Save();
            }
            return RedirectToAction("Details", "Harbour", new { countryCodeA2, harbourCode });
        }
    }
}
