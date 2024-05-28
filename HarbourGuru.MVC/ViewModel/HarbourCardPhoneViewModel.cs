using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.ViewModel
{
    public class HarbourCardPhoneViewModel
    {
        [Required]
        [MaxLength(20)]
        public string HarbourCardPhoneNumber { get; set; }

        public string HarbourCardPhoneDescription { get; set; }
    }
}
