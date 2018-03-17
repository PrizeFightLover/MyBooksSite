using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBooksSite.Models
{
    public class AdminViewModel
    {
        public class RoleViewModel
        {
            public string Id { get; set; }
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "RoleName")]
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class EditUserViewModel
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
}
