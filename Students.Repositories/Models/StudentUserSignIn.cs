using System.ComponentModel.DataAnnotations;

namespace Students.Repositories.Models
{
    public class StudentUserSignIn
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
