using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> Login(string email, string password);
    }
}