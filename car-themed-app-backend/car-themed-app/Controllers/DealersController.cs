using car_themed_app.Commands.Dealers;
using car_themed_app.Queries;
using car_themed_app.Queries.Dealers;
using car_themed_app_Repository.Dtos.DealerDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace car_themed_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DealersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDealers([FromQuery] PaginationQuery paginationQuery)
        {
            var query = new GetAllDealersQuery(paginationQuery);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{dealerId}")]
        public async Task<IActionResult> GetDealer(int dealerId)
        {
            var query = new GetDealerByIdQuery(dealerId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDealer([FromBody] NewDealerDto data)
        {
            var command = new CreateDealerCommand(data);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetDealer", new { dealerId = result.Id }, result);
        }

        [HttpDelete("{dealerId}")]
        public async Task<IActionResult> DeleteOrder(int dealerId)
        {
            var command = new DeleteDealerByIdCommand(dealerId);
            var result = await _mediator.Send(command);
            return result.ErrorMessage == string.Empty ? (IActionResult)NoContent() : NotFound(result.ErrorMessage);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDealer([FromBody] UpdateDealerDto data)
        {
            var command = new UpdateDealerCommand(data);
            var result = await _mediator.Send(command);
            return result.ErrorMessage == string.Empty ? (IActionResult)Ok() : NotFound(result.ErrorMessage);
        }
    }
}