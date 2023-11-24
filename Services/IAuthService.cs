using AspNetAuth.Models;

namespace AspNetAuth.Services
{
    public interface IAuthService
    {
        string generateTokenString(LoginUser user);
        Task<bool> Login(LoginUser user);
        Task<bool> RegisterUser(LoginUser user);
    }
}