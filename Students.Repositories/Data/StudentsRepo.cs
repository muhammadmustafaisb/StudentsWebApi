//using Students.Repositories.Models;

//namespace Students.Repositories.Data
//{
//    public class StudentsRepo : IStudentsRepo
//    {
//        public void CreateStudent(Student std)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Student> GetAllStudents()
//        {
//            List<Student> students = new List<Student>
//            {
//                new Student { StdId = 0, Name = "Muhammad Mustafa", FatherName = "Maqbool Elahi", Number = "03077167658" },
//                new Student { StdId = 1, Name = "Tom", FatherName = "Tomy", Number = "03077167555" },
//                new Student { StdId = 2, Name = "Honey", FatherName = "Tony", Number = "03077167888" }
//            };

//            return students;
//        }

//        public Student GetStudentById(int id)
//        {
//            return new Student { StdId = 0, Name = "Muhammad Mustafa", FatherName = "Maqbool Elahi", Number = "03077167658" };
//        }

//        public bool SaveChanges()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
