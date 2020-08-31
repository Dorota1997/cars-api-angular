using AutoMapper;
using car_themed_app_Repository.Dtos.OrderDtos;
using car_themed_app_Repository.Models;

namespace car_themed_app.Mapping
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<UpdateOrderDto, Order>();

            CreateMap<NewOrderDto, Order>();

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString("dd.MM.yyyy")))
                .ForMember(x => x.Dealer, opt => opt.MapFrom(src => src.Dealer.Name));
        }
    }
}
