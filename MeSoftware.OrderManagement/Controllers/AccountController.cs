using System;
using System.Threading.Tasks;
using MeSoftware.OrderManagement.Models;
using MeSoftware.OrderManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeSoftware.OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<UserRole> roleManager;

        public AccountController(UserManager<User> userManager,
            RoleManager<UserRole> roleManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpdateUserViewModel userView)
        {
            try
            {
                if (userView == null)
                    return BadRequest($"{nameof(userView)} cannot be null");

                var user = new User
                {
                    UserName = userView.UserName,
                    Email = userView.UserName
                };
                var result = await userManager.CreateAsync(user, userView.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
