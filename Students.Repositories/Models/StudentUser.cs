using Microsoft.AspNetCore.Identity;

namespace Students.Repositories.Models
{
    public class StudentUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
