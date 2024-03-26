using Microsoft.EntityFrameworkCore;
using Students.Repositories.Models;

namespace Students.Repositories.Data
{
    public class SqlStudentsRepo : IStudentsRepo
    {
        private readonly StudentContext _studentContext;

        public SqlStudentsRepo(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task CreateStudentAsync(Student std)
        {
            if (std == null)
            {
                throw new ArgumentNullException(nameof(std));
            }
            await _studentContext.Students.AddAsync(std);
             
        }

        public async Task DeleteStudentAsync(Student std)
        {
            if (std == null)
            {
                throw new ArgumentNullException(nameof(std));
            }
            _studentContext.Students.Remove(std);
            await _studentContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentContext.Students.ToListAsync(); 
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentContext.Students.FirstOrDefaultAsync(p => p.StdId == id); 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _studentContext.SaveChangesAsync()) >= 0;
        }

        public void UpdateStudent(Student std)
        {

        }
    }
}
