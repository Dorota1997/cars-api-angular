using car_themed_app.Queries.Orders;
using car_themed_app_Repository.Dtos;
using car_themed_app_Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Orders
{
    public class GetTotalOrderElementsAndPagesHandler
        : IRequestHandler<GetTotalOrderElementsAndPagesQuery, CountedElementsAndPagesDto>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetTotalOrderElementsAndPagesHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<CountedElementsAndPagesDto> Handle(GetTotalOrderElementsAndPagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _ordersRepository.GetTotalElementsAndPagesNumber(request.PageSize);
            return result;
        }
    }
}
