using HarbourGuru.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.ViewModel
{
    public class CountryViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
    }
}
