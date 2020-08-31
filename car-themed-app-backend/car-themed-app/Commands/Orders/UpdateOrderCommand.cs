using car_themed_app_Repository;
using car_themed_app_Repository.Dtos.OrderDtos;
using MediatR;

namespace car_themed_app.Commands.Orders
{
    public class UpdateOrderCommand : IRequest<Result<string>>
    {
        public UpdateOrderDto Order { get; }

        public UpdateOrderCommand(UpdateOrderDto order)
        {
            Order = order;
        }
    }
}
