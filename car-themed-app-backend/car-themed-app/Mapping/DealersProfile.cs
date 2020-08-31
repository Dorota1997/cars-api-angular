using AutoMapper;
using car_themed_app_Repository.Dtos.DealerDtos;
using car_themed_app_Repository.Models;

namespace car_themed_app.Mapping
{
    public class DealersProfile : Profile
    {
        public DealersProfile()
        {
            CreateMap<UpdateDealerDto, Dealer>();

            CreateMap<NewDealerDto, Dealer>();

            CreateMap<Dealer, DealerDto>();
        }
    }
}
