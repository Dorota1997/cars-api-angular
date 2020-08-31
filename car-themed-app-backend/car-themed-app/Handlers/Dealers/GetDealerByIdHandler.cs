using AutoMapper;
using car_themed_app.Queries.Dealers;
using car_themed_app_Repository.Dtos.DealerDtos;
using car_themed_app_Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Dealers
{
    public class GetDealerByIdHandler : IRequestHandler<GetDealerByIdQuery, DealerDto>
    {
        private readonly IDealersRepository _dealersRepository;
        private readonly IMapper _mapper;

        public GetDealerByIdHandler(IDealersRepository dealersRepository, IMapper mapper)
        {
            _dealersRepository = dealersRepository;
            _mapper = mapper;
        }

        public async Task<DealerDto> Handle(GetDealerByIdQuery request, CancellationToken cancellationToken)
        {
            var dealer = await _dealersRepository.GetDealerAsync(request.Id);
            return dealer == null ? null : _mapper.Map<DealerDto>(dealer);
        }
    }
}
