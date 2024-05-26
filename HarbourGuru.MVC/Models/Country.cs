using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountryCodeA2 { get; set; }

        [Required]
        [MaxLength(3)]
        public string CountryCodeA3 { get; set; }

        [Required]
        public string CountryFlagSmall { get; set; }

        [Required]
        public string CountryFlagLarge { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string CountryFullName { get; set; }

        public ICollection<Harbour> Harbours { get; set; } = new List<Harbour>();
    }
}
