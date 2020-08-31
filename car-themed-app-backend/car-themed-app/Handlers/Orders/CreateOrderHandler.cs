using AutoMapper;
using car_themed_app.Commands.Orders;
using car_themed_app_Repository.Interfaces;
using car_themed_app_Repository.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var mappedOrder = _mapper.Map<Order>(request.Order);
            var result = await _ordersRepository.CreateOrderAsync(mappedOrder);
            return result;
        }
    }
}
