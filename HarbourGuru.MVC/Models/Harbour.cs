using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarbourGuru.MVC.Models
{
    public class Harbour
    {
        [Key]
        public int HarbourId { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        [Required]
        [MaxLength(3)]
        public string HarbourCode { get; set; }
        [Required]
        public string HarbourName { get; set; }
        public ICollection<HarbourCard> HarbourCards { get; set; } = new List<HarbourCard>();
    }
}
