using HarbourGuru.MVC.Models;

namespace HarbourGuru.MVC.ViewModel
{
    public class HarbourViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCodeA2 { get; set; }
        public IEnumerable<Harbour> Harbours { get; set; }
    }
}
