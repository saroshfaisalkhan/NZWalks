using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandlerRepository tokenHandlerRepository;

        public AuthController(IUserRepository userRepository, ITokenHandlerRepository tokenHandlerRepository)
        {
            this.userRepository = userRepository;
            this.tokenHandlerRepository = tokenHandlerRepository;
        }

        

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsyn(LoginRequest loginRequest)
        {
            //1.Validate the loginRequest using fluet validation

            //2. Authenticate the loginRequest
            var user=await userRepository.AuthenticationAsync(loginRequest.Username, loginRequest.Password);

            if (user!=null)
            {
                //Generate a JWT token and send it back
               var key= tokenHandlerRepository.CreateTokenAsync(user);
                return Ok(key);
            }
            return BadRequest("Incorrect Username and Password");
        }
    }
}
