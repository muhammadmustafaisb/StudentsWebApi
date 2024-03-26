using Students.Repositories.Models;

namespace Students.Repositories.Data
{
    public interface IStudentsRepo
    {
        Task CreateStudentAsync(Student std);
        Task DeleteStudentAsync(Student std);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateStudent(Student std);
    }

}
