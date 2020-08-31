using AutoMapper;
using car_themed_app.Commands.Dealers;
using car_themed_app_Repository.Interfaces;
using car_themed_app_Repository.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Dealers
{
    public class CreateDealerHandler : IRequestHandler<CreateDealerCommand, Dealer>
    {
        private readonly IDealersRepository _dealersRepository;
        private readonly IMapper _mapper;

        public CreateDealerHandler(IDealersRepository dealersRepository, IMapper mapper)
        {
            _dealersRepository = dealersRepository;
            _mapper = mapper;
        }

        public async Task<Dealer> Handle(CreateDealerCommand request, CancellationToken cancellationToken)
        {
            var mappedDealer = _mapper.Map<Dealer>(request.Dealer);
            var result = await _dealersRepository.CreateDealerAsync(mappedDealer);
            return result;
        }
    }
}
