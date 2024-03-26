using Microsoft.AspNetCore.Mvc;
using Students.Repositories.Data;
using Students.Repositories.Models;

namespace Students.Controllers
{
    [Route("api/StudentUser")]
    [ApiController]
    public class StudentUserController : ControllerBase
    {
        private readonly IStudentUserRepo _studentUserRepo;

        public StudentUserController(IStudentUserRepo studentUserRepo)
        {
            _studentUserRepo = studentUserRepo;    
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]StudentUserSignUp studentUserSignUp) 
        {
            var result = await _studentUserRepo.SignUpAsync(studentUserSignUp);

            if (result.Succeeded) 
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn([FromBody] StudentUserSignIn studentUserSignIn)
        {
            var result = await _studentUserRepo.LoginAsync(studentUserSignIn);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }

    }
}
