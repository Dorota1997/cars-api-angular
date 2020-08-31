using AutoMapper;
using car_themed_app.Helpers;
using car_themed_app.Queries.Dealers;
using car_themed_app.Repository;
using car_themed_app.Services;
using car_themed_app_Contracts.Responses;
using car_themed_app_Repository.Dtos.DealerDtos;
using car_themed_app_Repository.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace car_themed_app.Handlers.Dealers
{
    public class GetAllDealersHandler : IRequestHandler<GetAllDealersQuery, PagedResponse<DealerDto>>
    {
        private readonly IDealersRepository _dealersRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public GetAllDealersHandler(IDealersRepository dealersRepository, IMapper mapper, IUriService uriService)
        {
            _dealersRepository = dealersRepository;
            _mapper = mapper;
            _uriService = uriService;
        }

        public async Task<PagedResponse<DealerDto>> Handle(GetAllDealersQuery request, CancellationToken cancellationToken)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(request.PaginationQuery);
            var orders = await _dealersRepository.GetAllDealersAsync(paginationFilter);
            var mappedDealers = _mapper.Map<List<DealerDto>>(orders);
            if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return new PagedResponse<DealerDto>(mappedDealers);
            }

            return PaginationHelpers.CreatePaginatedResponse(_uriService, paginationFilter, mappedDealers);
        }
    }
}
