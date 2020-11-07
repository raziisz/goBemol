using System.Threading.Tasks;
using backend.Models.Dto;

namespace backend.Repositories
{
    public interface IUsersRepository
    {
         Task Add(NewUser newUser);

         Task<bool> VerifyEmail(string email);
    }
}