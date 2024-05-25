using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public DateTime AddedTime { get; set; } = DateTime.UtcNow;
        public DateTime? LastHarbourCardAdded { get; set; }
        public DateTime? LastHarbourCardReviewAdded { get; set; }
        public ICollection<HarbourCardReview> Reviews { get; set; } = new List<HarbourCardReview>();
    }
}
