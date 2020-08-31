using System;
using System.Threading.Tasks;

namespace car_themed_app.Helpers
{
    public static class ValidationHelpers
    {
        public static Task<bool> BeValidDateFormat(string date)
        {
            DateTime parsedResult = date.TryToParseStringAsDateTime();
            if (parsedResult == DateTime.MinValue)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
