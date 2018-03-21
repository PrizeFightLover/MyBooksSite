using MyBooksSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBooksSite.ViewModels
{
    public class AuthorBooksViewModel
    {
        public Author Author { get; set; }
        [Display(Name = "Boekenlijst")]
        public List<Book> Books { get; set; }

        public AuthorBooksViewModel()
        {
            Books = new List<Book>();
        }
    }

}