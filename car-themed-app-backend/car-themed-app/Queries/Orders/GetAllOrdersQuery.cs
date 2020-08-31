using car_themed_app_Contracts.Responses;
using car_themed_app_Repository.Dtos.OrderDtos;
using MediatR;

namespace car_themed_app.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<PagedResponse<OrderDto>>
    {
        public PaginationQuery PaginationQuery { get; set; }

        public GetAllOrdersQuery(PaginationQuery paginationQuery)
        {
            PaginationQuery = paginationQuery;
        }
    }
}
