using AutoMapper;
using car_themed_app.Commands.Dealers;
using car_themed_app_Repository;
using car_themed_app_Repository.Interfaces;
using car_themed_app_Repository.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static car_themed_app_Repository.GenericResultMethods;

namespace car_themed_app.Handlers.Dealers
{
    public class UpdateDealerHandler : IRequestHandler<UpdateDealerCommand, Result<string>>
    {
        private readonly IDealersRepository _dealersRepository;
        private readonly IMapper _mapper;

        public UpdateDealerHandler(IDealersRepository dealersRepository, IMapper mapper)
        {
            _dealersRepository = dealersRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(UpdateDealerCommand request, CancellationToken cancellationToken)
        {
            bool objExists = await _dealersRepository.CheckIfDealerExists(request.Dealer.Id);
            if (objExists)
            {
                var mappedDealer = _mapper.Map<Dealer>(request.Dealer);
                _dealersRepository.UpdateDealer(mappedDealer);
                return Ok<string>();
            }
            return ErrorMessage<string>($"Dealer {request.Dealer.Id} does not exist.");
        }
    }
}
