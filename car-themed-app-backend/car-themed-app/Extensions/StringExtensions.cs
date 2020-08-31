using System.Globalization;

namespace System
{
    public static class StringExtensions
    {
        public static DateTime TryToParseStringAsDateTime(this string value)
        {
            // dd would expect always 2 digit day format e.g. 01, 02 
            return GetParseResult(value, "d.MM.yyyy");
        }

        private static DateTime GetParseResult(string value, string expectedDateFormat)
        {
            var result = 
                DateTime.TryParseExact(value, expectedDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

            if(result == false)
            {
                return DateTime.MinValue;
            } 
            else
            {
                return date;
            }
        }
    }
}
