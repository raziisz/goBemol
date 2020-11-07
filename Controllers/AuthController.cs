using System.Threading.Tasks;
using backend.Models.Dto;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;

        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(Login login)
        {
            var user = await authRepository.Login(login);

            if (user == null) return BadRequest(new { message = "Usuário ou senha inválida."});

            return Ok(new { 
                Nome = user.Nome,
                Sobrenome = user.Sobrenome,
                Email = user.Email
             });
        }
    }
}