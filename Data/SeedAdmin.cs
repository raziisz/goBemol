using System.Linq;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Data
{
    public class SeedAdmin
    {
         private readonly DataContext _context;
        public SeedAdmin(DataContext context)
        {
            _context = context;

        }

        public void SeedUsers()
        {
            if(!_context.Users.Any()) {
                var userData = System.IO.File.ReadAllText("Data/UserAdminData.json");
                var user = JsonConvert.DeserializeObject<User>(userData);
                
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("123456", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;


                _context.Users.Add(user);
                

                _context.SaveChanges();
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }
    }
}