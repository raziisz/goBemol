using System.Threading.Tasks;
using backend.Data;
using backend.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        public AuthRepository(DataContext context)
        {
            this.context = context;

        }
        public async Task<bool> Login(Login login)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user == null) return false;
            if (!VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt)) return false;

            return true;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i< computedHash.Length; i++){
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}