﻿using HarbourGuru.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace HarbourGuru.MVC.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
    }
}
