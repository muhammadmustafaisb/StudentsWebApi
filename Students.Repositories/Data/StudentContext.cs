using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Students.Repositories.Models;

namespace Students.Repositories.Data
{
    public class StudentContext : IdentityDbContext<StudentUser>
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
