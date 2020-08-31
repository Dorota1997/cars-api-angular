using car_themed_app.Queries;
using System;

namespace car_themed_app.Services
{
    public interface IUriService
    {
        Uri GetAllPostUri(PaginationQuery paginationQuery = null);
    }
}
