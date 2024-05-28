using HarbourGuru.MVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.ViewModel
{
    public class HarbourCardCreateViewModel
    {
        public int HarbourId { get; set; }
        [Required]
        [MaxLength(2)]
        public string CountryCodeA2 { get; set; }
        [Required]
        [MaxLength(3)]
        public string HarbourCode { get; set; }
        [Required]
        public int HarbourCardCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Url]
        public string? Website { get; set; }
        [BindNever]
        public List<HarbourCardCategory>? Categories { get; set; } = new List<HarbourCardCategory>();
        public List<HarbourCardPhoneViewModel> Phones { get; set; } = new List<HarbourCardPhoneViewModel>();
    }


}
