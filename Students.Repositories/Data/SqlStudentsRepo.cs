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

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentContext.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _studentContext.Students.FirstOrDefault(p => p.StdId == id);
        }

        public bool SaveChanges()
        {
            return (_studentContext.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student std)
        {

        }
    }
}
