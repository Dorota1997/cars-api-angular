namespace car_themed_app_Repository
{
    public class Result<T>
    {
        public T SuccessResult { get; set; }

        public string ErrorMessage { get; set; }
    }

    public static class GenericResultMethods
    {
        public static Result<T> ErrorMessage<T>(string message) where T : class 
        {
            return new Result<T>
            {
                ErrorMessage = message
            };
        }

        public static Result<T> Ok<T>() where T : class 
        {
            return new Result<T>
            {
                ErrorMessage = string.Empty
            };
        }
    }
}
