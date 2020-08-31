using car_themed_app_Repository.Dtos.DealerDtos;
using MediatR;

namespace car_themed_app.Queries.Dealers
{
    public class GetDealerByIdQuery : IRequest<DealerDto>
    {
        public int Id { get; }

        public GetDealerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
