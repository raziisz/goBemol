using System.Threading.Tasks;
using backend.Models.Dto;
using backend.Repositories;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        private readonly IConfiguration config;
        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {
            this.config = config;
            this.authRepository = authRepository;

        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(Login login)
        {
            var user = await authRepository.Login(login);

            if (user == null) return BadRequest(new { message = "Usuário ou senha inválida." });

            var token = TokenService.GenerateTokenUser(user, config);
            
            return Ok(new
            {
                user = new {
                    Nome = user.Nome,
                    Sobrenome = user.Sobrenome,
                    Email = user.Email
                },
                token
            });
        }
    }
}