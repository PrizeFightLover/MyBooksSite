using MyBooksSite.Models;

namespace MyBooksSite.ViewModels
{
    public class BookRatingViewModel
    {
        public double AverageRating { get; set; }
        public int SumRatings { get; set; }
        public int NumberOfRatings { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}