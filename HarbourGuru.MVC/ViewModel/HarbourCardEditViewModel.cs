using HarbourGuru.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.ViewModel
{
    public class HarbourCardEditViewModel
    {
        public int HarbourCardId { get; set; }

        [Required]
        public int HarbourId { get; set; }

        [Required]
        public int HarbourCardCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Url]
        public string? Website { get; set; }

        public List<HarbourCardCategory> Categories { get; set; } = new List<HarbourCardCategory>();
        public List<HarbourCardPhoneViewModel> Phones { get; set; } = new List<HarbourCardPhoneViewModel>();
        public IFormFile? Image { get; set; }
        public string? ExistingImageUrl { get; set; }
    }
}
