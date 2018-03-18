using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBooksSite.ViewModels
{
    public class AdminIndexUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Rechten")]
        public List<string> Roles { get; set; }
    }
}