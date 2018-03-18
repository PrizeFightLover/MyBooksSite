using MyBooksSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBooksSite.ViewModels
{
    public class BookRatingViewModel
    {
        public Book Book { get; set; }
        [Display(Name = "Beoordeling")]
        public double AverageRating { get; set; }
        public int numberOfRatings { get; set; }
        public int Rating { get; set; }
    }
}