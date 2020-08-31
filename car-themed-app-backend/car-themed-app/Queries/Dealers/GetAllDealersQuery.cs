using car_themed_app_Contracts.Responses;
using car_themed_app_Repository.Dtos.DealerDtos;
using MediatR;

namespace car_themed_app.Queries.Dealers
{
    public class GetAllDealersQuery : IRequest<PagedResponse<DealerDto>>
    {
        public PaginationQuery PaginationQuery { get; set; }

        public GetAllDealersQuery(PaginationQuery paginationQuery)
        {
            PaginationQuery = paginationQuery;
        }
    }
}
