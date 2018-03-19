using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBooksSite.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public int SumRatings { get; set; }
        public int NumberOfRatings { get; set; }
        public string Description { get; set; }
    }
}

