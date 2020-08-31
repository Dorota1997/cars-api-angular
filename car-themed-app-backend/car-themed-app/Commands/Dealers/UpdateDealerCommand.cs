using car_themed_app_Repository;
using car_themed_app_Repository.Dtos.DealerDtos;
using MediatR;

namespace car_themed_app.Commands.Dealers
{
    public class UpdateDealerCommand : IRequest<Result<string>>
    {
        public UpdateDealerDto Dealer { get; }

        public UpdateDealerCommand(UpdateDealerDto dealer)
        {
            Dealer = dealer;
        }
    }
}
