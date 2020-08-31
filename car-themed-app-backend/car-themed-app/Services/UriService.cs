using car_themed_app.Queries;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace car_themed_app.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllPostUri(PaginationQuery paginationQuery = null)
        {
            Uri uri = new Uri(_baseUri);
            if(paginationQuery == null)
            {
                return uri;
            }
            string modifiedUri = AddQueryToString(_baseUri, "pageNumber", paginationQuery.PageNumber.ToString());
            modifiedUri = AddQueryToString(modifiedUri, "pageSize", paginationQuery.PageSize.ToString());
            return new Uri(modifiedUri);
        }

        private string AddQueryToString(string currentString, string parameterName, string parameterValue)
        {
            return QueryHelpers.AddQueryString(currentString, parameterName, parameterValue);
        }
    }
}
