using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBooksSite.ViewModels
{
    public class AdminEditUserViewModel
    {
            public string Id { get; set; }

            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [MaxLength(255)]
            [Display(Name = "Gebruikersnaam")]
            public string UserName { get; set; }
            public IEnumerable<SelectListItem> RolesList { get; set; }
       
    }
}