using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Students.Repositories.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Students.Repositories.Data
{
    public class StudentUserRepo : IStudentUserRepo
    {
        private readonly UserManager<StudentUser> _userManager;
        private readonly SignInManager<StudentUser> _signInManager;
        private readonly IConfiguration _configuration;

        public StudentUserRepo(UserManager<StudentUser> userManager, SignInManager<StudentUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> SignUpAsync(StudentUserSignUp studentUserSignUp) 
        {
            var user = new StudentUser() 
            { 
                Name = studentUserSignUp.Name,
                Email = studentUserSignUp.Email,
                UserName = studentUserSignUp.Email
            };

            return await _userManager.CreateAsync(user, studentUserSignUp.Password);

        }

        public async Task<string> LoginAsync(StudentUserSignIn studentUserSignIn) 
        {
            var result = await _signInManager.PasswordSignInAsync(studentUserSignIn.Email, studentUserSignIn.Password, false, false);

            if (!result.Succeeded) 
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, studentUserSignIn.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
