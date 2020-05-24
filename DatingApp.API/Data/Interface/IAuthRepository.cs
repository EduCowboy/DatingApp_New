using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data.Interface
{
    public interface IAuthRepository
    {
        Task<User> Register(User user);
        Task<User> Login(string username);
        Task<bool> UserExists(string username);
    }
}