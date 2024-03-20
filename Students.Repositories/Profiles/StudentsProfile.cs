using AutoMapper;
using Students.Repositories.Dto;
using Students.Repositories.Models;

namespace Students.Repositories.Profiles
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
