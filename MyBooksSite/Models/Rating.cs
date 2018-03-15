using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBooksSite.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 5)]
        public int Stars { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public int BookId { get; set; }

    }
}