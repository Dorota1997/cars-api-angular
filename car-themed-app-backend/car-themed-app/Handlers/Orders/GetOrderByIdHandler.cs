using AutoMapper;
using car_themed_app.Queries.Orders;
using car_themed_app_Repository.Dtos.OrderDtos;
using car_themed_app_Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Orders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetOrderAsync(request.Id);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }
    }
}
