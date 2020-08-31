using car_themed_app_Repository;
using MediatR;

namespace car_themed_app.Commands.Dealers
{
    public class DeleteDealerByIdCommand : IRequest<Result<string>>
    {
        public int Id { get; }

        public DeleteDealerByIdCommand(int id)
        {
            Id = id;
        }
    }
}
