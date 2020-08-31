using car_themed_app.Commands.Orders;
using car_themed_app.Queries;
using car_themed_app.Queries.Orders;
using car_themed_app_Repository.Dtos.OrderDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace car_themed_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] PaginationQuery paginationQuery)
        {
            var query = new GetAllOrdersQuery(paginationQuery);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{orderId}")] 
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var query = new GetOrderByIdQuery(orderId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrderDto data)
        {
            var command = new CreateOrderCommand(data);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetOrder", new { orderId = result.Id }, result);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var command = new DeleteOrderByIdCommand(orderId);
            var result = await _mediator.Send(command);
            return result.ErrorMessage == string.Empty ? (IActionResult) NoContent() : NotFound(result.ErrorMessage);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto data)
        {
            var command = new UpdateOrderCommand(data);
            var result = await _mediator.Send(command);
            return result.ErrorMessage == string.Empty ? (IActionResult) Ok() : NotFound(result.ErrorMessage);
        }
    }
}