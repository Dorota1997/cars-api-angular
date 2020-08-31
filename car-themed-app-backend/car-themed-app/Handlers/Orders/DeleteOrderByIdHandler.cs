using car_themed_app.Commands.Orders;
using car_themed_app_Repository;
using car_themed_app_Repository.Interfaces;
using car_themed_app_Repository.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static car_themed_app_Repository.GenericResultMethods;

namespace car_themed_app.Handlers.Orders
{
    public class DeleteOrderByIdHandler : IRequestHandler<DeleteOrderByIdCommand, Result<string>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public DeleteOrderByIdHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Result<string>> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
        {
            Order order = await _ordersRepository.GetOrderAsync(request.Id);
            if(order != null)
            {
                _ordersRepository.DeleteOrder(request.Id);
                return Ok<string>();
            }
            return ErrorMessage<string>($"Order {request.Id} does not exist.");
        }
    }
}
