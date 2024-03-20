using Students.Repositories.Models;

namespace Students.Repositories.Data
{
    public interface IStudentsRepo
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        Task CreateStudentAsync(Student std);
        bool SaveChanges();
        void UpdateStudent(Student std);
        Task DeleteStudentAsync(Student std);
    }

}
