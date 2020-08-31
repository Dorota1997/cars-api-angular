using car_themed_app_Repository.Dtos.OrderDtos;
using MediatR;
using System;

namespace car_themed_app.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
