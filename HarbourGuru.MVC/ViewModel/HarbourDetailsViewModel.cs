using HarbourGuru.MVC.Models;

namespace HarbourGuru.MVC.ViewModel
{
    public class HarbourDetailsViewModel
    {
        public int HarbourId { get; set; }
        public string HarbourCode { get; set; }
        public string HarbourName { get; set; }
        public string CountryName { get; set; }
        public string CountryCodeA2 { get; set; }
        public ICollection<HarbourCard> HarbourCards { get; set; }
    }
}
