using car_themed_app.Queries;
using car_themed_app.Repository;
using car_themed_app.Services;
using car_themed_app_Contracts.Responses;
using System.Collections.Generic;

namespace car_themed_app.Helpers
{
    public class PaginationHelpers
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter paginationFilter, List<T> elements)
        {
            string nextPage = paginationFilter.PageNumber >= 1 ?
                uriService.GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;

            string previousPage = paginationFilter.PageNumber - 1 >= 1 ?
                uriService.GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

            return new PagedResponse<T>
            {
                Data = elements,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null,
                NextPage = elements.Count != 0 ? nextPage : null,
                PreviousPage = previousPage
            };
        }
    }
}
