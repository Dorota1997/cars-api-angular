using MediatR;
using car_themed_app_Repository.Models;
using car_themed_app_Repository.Dtos.OrderDtos;

namespace car_themed_app.Commands.Orders
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public NewOrderDto Order { get; }

        public CreateOrderCommand(NewOrderDto order)
        {
            Order = order;
        }
    }
}
