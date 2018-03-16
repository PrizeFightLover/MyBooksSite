using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBooksSite.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(0, 5)]
        public int Stars { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }

    }
}