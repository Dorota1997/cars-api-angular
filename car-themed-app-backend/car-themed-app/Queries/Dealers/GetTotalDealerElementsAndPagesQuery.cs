using car_themed_app_Repository.Dtos;
using MediatR;

namespace car_themed_app.Queries.Dealers
{
    public class GetTotalDealerElementsAndPagesQuery : IRequest<CountedElementsAndPagesDto>
    {
        public int PageSize { get; }

        public GetTotalDealerElementsAndPagesQuery(int pageSize)
        {
            PageSize = pageSize;
        }
    }
}
