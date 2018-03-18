using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBooksSite.Models
{
    public class BookRating
    {
        public int Id { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }

    }
}