using MeSoftware.Exceptions.Api;
using MeSoftware.OrderManagement.Services;
using MeSoftware.OrderManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MeSoftware.OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public SignInController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserLoginViewModel userDto)
        {
            try
            {
                return Ok(tokenService.Authenticate(userDto));
            }
            catch (MeAuthenticateException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch
            {
                throw;
            }
        }
    }
}
