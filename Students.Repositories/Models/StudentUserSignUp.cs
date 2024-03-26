
using System.ComponentModel.DataAnnotations;

namespace Students.Repositories.Models
{
    public class StudentUserSignUp
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
