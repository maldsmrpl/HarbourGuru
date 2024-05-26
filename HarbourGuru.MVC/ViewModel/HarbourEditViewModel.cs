using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.ViewModel
{
    public class HarbourEditViewModel
    {
        public int HarbourId { get; set; }

        [Required]
        [MaxLength(3)]
        public string HarbourCode { get; set; }

        [Required]
        public string HarbourName { get; set; }

        public int CountryId { get; set; }
    }
}
