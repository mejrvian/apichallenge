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
    public class POrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public POrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePOrder([FromBody] PurchaseOrderViewModel viewModel)
        {
            try
            {
                return Ok(await mediator.Send(new POQueries.AddCommand(viewModel)));
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
