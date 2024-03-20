using AutoMapper;
using Students.DataAccessLayer.StudentsDto;
using Students.Repositories.Models;

namespace Students.DataAccessLayer.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            //Source -> Target 
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();

        }
    }
}
