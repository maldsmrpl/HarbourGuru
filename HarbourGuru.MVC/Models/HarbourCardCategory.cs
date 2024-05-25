using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.Models
{
    public class HarbourCardCategory
    {
        [Key]
        public int HarbourCardCategoryId { get; set; }
        [Required]
        public string HarbourCardCategoryName { get; set; }
    }
}
