using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Students.Repositories.Models;
using Microsoft.AspNetCore.JsonPatch;
using Students.Repositories.Data;
using Students.Repositories.Dto;

namespace Students.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepo _studentRepo;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsRepo studentsRepo, IMapper mapper)
        {
            _studentRepo = studentsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var studentItems = _studentRepo.GetAllStudents();

            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(studentItems));
        }

        [HttpGet("{id}")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var studentItem = _studentRepo.GetStudentById(id);
            if (studentItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StudentReadDto>(studentItem));
        }

        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            _studentRepo.CreateStudentAsync(studentModel);
            _studentRepo.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return Ok(studentReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var studentModelFromRepo = _studentRepo.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(studentUpdateDto, studentModelFromRepo);

            _studentRepo.UpdateStudent(studentModelFromRepo);

            _studentRepo.SaveChanges();

            return Ok();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var studentModelFromRepo = _studentRepo.GetStudentById(id);

            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelFromRepo);
            patchDoc.ApplyTo(studentToPatch, ModelState);

            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentModelFromRepo);

            _studentRepo.UpdateStudent(studentModelFromRepo);

            _studentRepo.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudentById(int id) 
        {
            var studentModelFromRepo = _studentRepo.GetStudentById(id);

            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            _studentRepo.DeleteStudentAsync(studentModelFromRepo);
            _studentRepo.SaveChanges();

            return Ok();
        }

    }
}
