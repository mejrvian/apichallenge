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
    public class ProductReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime begDate, [FromQuery] DateTime endDate)
        {
            try
            {
                return Ok(await mediator.Send(new ProductReportQueries.ReportLinesQuery(begDate, endDate)));
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
