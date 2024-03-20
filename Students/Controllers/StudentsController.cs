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
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetAllStudents()
        {
            var studentItems = _studentRepo.GetAllStudentsAsync();

            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(await studentItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetStudentById(int id)
        {
            var studentItem = _studentRepo.GetStudentByIdAsync(id);
            if (studentItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StudentReadDto>(await studentItem));
        }

        [HttpPost]
        public async Task<ActionResult<StudentReadDto>> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            await _studentRepo.CreateStudentAsync(studentModel);
            await _studentRepo.SaveChangesAsync();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return Ok(studentReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var studentModelFromRepo =await _studentRepo.GetStudentByIdAsync(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(studentUpdateDto, studentModelFromRepo);

            _studentRepo.UpdateStudent(studentModelFromRepo);

           await _studentRepo.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var studentModelFromRepo =await _studentRepo.GetStudentByIdAsync(id);

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

            await _studentRepo.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentById(int id) 
        {
            var studentModelFromRepo = _studentRepo.GetStudentByIdAsync(id);

            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            await _studentRepo.DeleteStudentAsync( await studentModelFromRepo);
            await _studentRepo.SaveChangesAsync();

            return Ok();
        }

    }
}
