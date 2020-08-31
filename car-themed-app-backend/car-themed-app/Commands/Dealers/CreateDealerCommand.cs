using car_themed_app_Repository.Dtos.DealerDtos;
using car_themed_app_Repository.Models;
using MediatR;

namespace car_themed_app.Commands.Dealers
{
    public class CreateDealerCommand : IRequest<Dealer>
    {
        public NewDealerDto Dealer { get; }

        public CreateDealerCommand(NewDealerDto dealer)
        {
            Dealer = dealer;
        }
    }
}
