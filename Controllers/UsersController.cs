using System.Threading.Tasks;
using backend.Models.Dto;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUnityOfWork uof;
        private readonly IUsersRepository usersRepository;
        public UsersController(
            IUsersRepository usersRepository,
            IUnityOfWork uof
        )
        {
            this.uof = uof;
            this.usersRepository = usersRepository;
            
        }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(NewUser newUser)
    {

        var emailUsed = await usersRepository.VerifyEmail(newUser.Email);

        if (emailUsed) return BadRequest(new { message = "Este e-mail já está em uso." });

        await usersRepository.Add(newUser);

        if (await uof.Commit()) {
            return Ok(new { message = $"Conta criada com sucesso, comece logando."});
        }

        return StatusCode(500, new { message = "Ocorreu um erro no servidor"});

    }
}
}