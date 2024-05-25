using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(2)]
        public string CountryCode { get; set; }
        [Required]
        public string CountryName { get; set; }
        public ICollection<Harbour> Harbours { get; set; } = new List<Harbour>();
    }
}
