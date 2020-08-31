using AutoMapper;
using car_themed_app.Helpers;
using car_themed_app.Queries.Orders;
using car_themed_app.Repository;
using car_themed_app.Services;
using car_themed_app_Contracts.Responses;
using car_themed_app_Repository.Dtos.OrderDtos;
using car_themed_app_Repository.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, PagedResponse<OrderDto>>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;


        public GetAllOrdersHandler(IOrdersRepository ordersRepository, IMapper mapper, IUriService uriService)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _uriService = uriService;
        }

        public async Task<PagedResponse<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(request.PaginationQuery);
            var orders = await _ordersRepository.GetAllOrdersAsync(paginationFilter);
            var mappedOrders = _mapper.Map<List<OrderDto>>(orders);
            if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return new PagedResponse<OrderDto>(mappedOrders);
            }

            return PaginationHelpers.CreatePaginatedResponse(_uriService, paginationFilter, mappedOrders);
        }
    }
}
