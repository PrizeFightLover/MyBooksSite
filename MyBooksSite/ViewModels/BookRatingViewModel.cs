using MyBooksSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBooksSite.ViewModels
{
    public class BookRatingViewModel
    {
        public Book Book { get; set; }
        public double AverageRating { get; set; }
    }
}