using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarbourGuru.MVC.Models
{
    public class HarbourCardReview
    {
        [Key]
        public int HarbourCardReviewId { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        
        [ForeignKey(nameof(HarbourCard))]
        public int HarbourCardId { get; set; }
        public virtual HarbourCard HarbourCard { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int Score { get; set; }
        
        [Required]
        public string Comment { get; set; }
    }
}
