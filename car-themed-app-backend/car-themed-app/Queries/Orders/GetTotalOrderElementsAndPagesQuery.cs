using car_themed_app_Repository.Dtos;
using MediatR;

namespace car_themed_app.Queries.Orders
{
    public class GetTotalOrderElementsAndPagesQuery : IRequest<CountedElementsAndPagesDto>
    {
        public int PageSize { get; }

        public GetTotalOrderElementsAndPagesQuery(int pageSize)
        {
            PageSize = pageSize;
        }
    }
}
