using HarbourGuru.MVC.Models;

namespace HarbourGuru.MVC.ViewModel
{
    public class HarbourCardViewModel
    {
        public int HarbourId { get; set; }
        public string HarbourName { get; set; }
        public IEnumerable<HarbourCard> HarbourCards { get; set; }
    }
}
