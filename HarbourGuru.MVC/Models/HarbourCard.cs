using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarbourGuru.MVC.Models
{
    public class HarbourCard
    {
        [Key]
        public int HarbourCardId { get; set; }

        [ForeignKey(nameof(Harbour))]
        public int HarbourId { get; set; }
        public virtual Harbour Harbour { get; set; }
        
        [ForeignKey(nameof(HarbourCardCategory))]
        public int HarbourCardCategoryId { get; set; }
        public virtual HarbourCardCategory HarbourCardCategory { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string? Description { get; set; }
        
        public ICollection<HarbourCardPhone> Phones { get; set; } = new List<HarbourCardPhone>();
        public string? Email { get; set; }
        public string? Website { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }
        
        public ICollection<HarbourCardReview> Reviews { get; set; } = new List<HarbourCardReview>();
    }
}
