using car_themed_app.Helpers;

namespace FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> DateValidation<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("Order date cannot be empty.")
                .MustAsync(async (orderDate, cancellation) => await ValidationHelpers.BeValidDateFormat(orderDate))
                .WithMessage("Order date must be of format: d.MM.yyyy e.g. 12.02.2012");
        }

        public static IRuleBuilderOptions<T, string> ComponentValidation<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("Components field cannot be empty.")
                .MaximumLength(150)
                .WithMessage("Components field length overflow. Max allowed length is 200");
        }

        public static IRuleBuilderOptions<T, string> TextFieldValidation<T>(this IRuleBuilder<T, string> rule, int minLength, int maxLength)
        {
            return rule
                .NotEmpty()
                .MinimumLength(minLength)
                .MaximumLength(maxLength);
        }
    }
}
