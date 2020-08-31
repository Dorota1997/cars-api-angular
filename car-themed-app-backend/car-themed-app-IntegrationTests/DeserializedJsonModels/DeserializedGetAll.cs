using System.Collections.Generic;

namespace car_themed_app_IntegrationTests.DeserializedJsonModels
{
    public class DeserializedGetAll<T>
    {
        public List<T> Data { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string NextPage { get; set; }

        public string PreviousPage { get; set; }
    }
}
