using System;
using System.Threading.Tasks;
using MediatR;
using MeSoftware.Exceptions.Api;
using MeSoftware.OrderManagement.MediatR;
using MeSoftware.OrderManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeSoftware.OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("list/{namefilter}")]
        public async Task<IActionResult> CustomerList([FromRoute] string namefilter)
        {
            try
            {
                return Ok(await mediator.Send(new CustomersQueries.ListQuery(namefilter)));
            }
            catch (MeAuthenticateException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> NewCustomer([FromBody] CustomerViewModel viewModel)
        {
            try
            {
                return Ok(await mediator.Send(new CustomersQueries.AddCommand(viewModel)));
            }
            catch (MeAuthenticateException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
