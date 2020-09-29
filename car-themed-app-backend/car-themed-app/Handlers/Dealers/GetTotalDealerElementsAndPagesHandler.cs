using car_themed_app.Queries.Dealers;
using car_themed_app_Repository.Dtos;
using car_themed_app_Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Dealers
{
    public class GetTotalDealerElementsAndPagesHandler : 
        IRequestHandler<GetTotalDealerElementsAndPagesQuery, CountedElementsAndPagesDto>
    {
        private readonly IDealersRepository _dealersRepository;

        public GetTotalDealerElementsAndPagesHandler(IDealersRepository dealersRepository)
        {
            _dealersRepository = dealersRepository;
        }

        public async Task<CountedElementsAndPagesDto> Handle(GetTotalDealerElementsAndPagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dealersRepository.GetTotalElementsAndPagesNumber(request.PageSize);
            return result;
        }
    }
}
