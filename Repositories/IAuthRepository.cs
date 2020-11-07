using System.Threading.Tasks;
using backend.Models.Dto;

namespace backend.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> Login(Login login);
    }
}