using Microsoft.AspNetCore.Identity;
using Students.Repositories.Models;

namespace Students.Repositories.Data
{
    public interface IStudentUserRepo
    {
        Task<IdentityResult> SignUpAsync(StudentUserSignUp studentUserSignUp);

        Task<string> LoginAsync(StudentUserSignIn studentUserSignIn);
    }
}