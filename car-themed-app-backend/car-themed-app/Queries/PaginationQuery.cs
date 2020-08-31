namespace car_themed_app.Queries
{
    public class PaginationQuery
    {
        private readonly int _defaultMaxPageSize = 10;

        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = _defaultMaxPageSize;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize > _defaultMaxPageSize ? _defaultMaxPageSize : pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

    }
}
