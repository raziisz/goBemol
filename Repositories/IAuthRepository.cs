using System.Threading.Tasks;
using backend.Models;
using backend.Models.Dto;

namespace backend.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Login(Login login);
    }
}