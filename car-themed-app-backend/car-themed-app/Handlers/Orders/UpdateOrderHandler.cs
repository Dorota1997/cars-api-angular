using AutoMapper;
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
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Result<string>>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            bool objExists = await _ordersRepository.CheckIfOrderExists(request.Order.Id);
            if(objExists)
            {
                var mappedOrder = _mapper.Map<Order>(request.Order);
                _ordersRepository.UpdateOrder(mappedOrder);
                return Ok<string>();
            }
            return ErrorMessage<string>($"Order {request.Order.Id} does not exist.");
        }
    }
}
