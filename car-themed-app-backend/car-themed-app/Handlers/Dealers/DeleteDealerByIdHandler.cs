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
    public class DeleteDealerByIdHandler : IRequestHandler<DeleteDealerByIdCommand, Result<string>>
    {
        private readonly IDealersRepository _dealersRepository;

        public DeleteDealerByIdHandler(IDealersRepository dealersRepository)
        {
            _dealersRepository = dealersRepository;
        }

        public async Task<Result<string>> Handle(DeleteDealerByIdCommand request, CancellationToken cancellationToken)
        {
            Dealer dealer = await _dealersRepository.GetDealerAsync(request.Id);
            if (dealer != null)
            {
                _dealersRepository.DeleteDealer(request.Id);
                return Ok<string>();
            }
            return ErrorMessage<string>($"Dealer {request.Id} does not exist.");
        }
    }
}
