using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
            
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(string email, string password) {
            return null;
        }
    }
}