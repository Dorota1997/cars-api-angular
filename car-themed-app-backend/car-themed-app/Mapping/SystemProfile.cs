using AutoMapper;
using System;

namespace car_themed_app.Mapping
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<string, DateTime>()
                .ConvertUsing<StringToDateTimeConverter>();
        }

        public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                return source.TryToParseStringAsDateTime();
            }
        }
    }
}
