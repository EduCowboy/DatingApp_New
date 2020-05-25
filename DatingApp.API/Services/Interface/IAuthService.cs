using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Services.Interface
{
    public interface IAuthService
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
         SecurityToken CreateToken(string idString, string username);
    }
}