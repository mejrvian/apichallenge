using System;
using System.Threading.Tasks;
using MediatR;
using MeSoftware.Exceptions.Api;
using MeSoftware.OrderManagement.MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeSoftware.OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("list/{namefilter}")]
        public async Task<IActionResult> CustomerList([FromRoute] string namefilter)
        {
            try
            {
                return Ok(await mediator.Send(new ProductQueries.ListQuery(namefilter)));
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
