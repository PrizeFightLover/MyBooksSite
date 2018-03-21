using MyBooksSite.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBooksSite.ViewModels
{
    public class BookRatingViewModel
    {
        [Display(Name = "Beoordeling")]
        public double AverageRating { get; set; }
        public int SumRatings { get; set; }
        public int NumberOfRatings { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}