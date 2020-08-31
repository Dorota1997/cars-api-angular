using AutoMapper;
using car_themed_app.Queries;
using car_themed_app.Repository;

namespace car_themed_app.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}
