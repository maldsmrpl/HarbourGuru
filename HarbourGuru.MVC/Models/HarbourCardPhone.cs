using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarbourGuru.MVC.Models
{
    public class HarbourCardPhone
    {
        [Key]
        public int HarbourCardPhoneId { get; set; }

        [ForeignKey(nameof(HarbourCard))]
        public int HarbourCardId { get; set; }
        public virtual HarbourCard HarbourCard { get; set; }

        public string HarbourCardPhoneDescription { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string HarbourCardPhoneNumber { get; set; }
    }
}
