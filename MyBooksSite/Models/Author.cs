using System.ComponentModel.DataAnnotations;

namespace MyBooksSite.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }
    }
}