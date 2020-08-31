using car_themed_app_Repository;
using MediatR;

namespace car_themed_app.Commands.Orders
{
    public class DeleteOrderByIdCommand : IRequest<Result<string>>
    {
        public int Id { get; }

        public DeleteOrderByIdCommand(int id)
        {
            Id = id;
        }
    }
}
