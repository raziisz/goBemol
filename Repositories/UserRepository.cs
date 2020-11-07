using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using backend.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly DataContext context;
        public UserRepository(DataContext context)
        {
            this.context = context;

        }
        public async Task Add(NewUser newUser)
        {
            byte[] passwordHash, passwordSalt;
            var user = new User();

            user.Nome = newUser.Nome;
            user.Sobrenome = newUser.Sobrenome;
            user.Email = newUser.Email.ToLower();
            user.Endereco = newUser.Endereco;
            user.CEP = newUser.CEP;
            user.Numero = newUser.Numero;
            user.Cidade = newUser.Cidade;
            user.Estado = newUser.Estado;


            CreatePasswordHash(newUser.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);

        }

        public async Task<bool> VerifyEmail(string email)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

            return !(user == null);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}