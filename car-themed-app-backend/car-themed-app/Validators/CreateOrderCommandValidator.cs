using car_themed_app.Commands.Orders;
using car_themed_app_Repository.Interfaces;
using FluentValidation;

namespace car_themed_app.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(IDealersRepository dealersRepository)
        {
            RuleFor(r => r.Order.Components)
                .Cascade(CascadeMode.Stop)
                .ComponentValidation();

            RuleFor(r => r.Order.OrderDate)
                .Cascade(CascadeMode.Stop)
                .DateValidation();

            RuleFor(r => r.Order.DealerId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("DealerId cannot be empty.")
                .GreaterThan(0)
                .WithMessage("DealerId must be greater than 1.")
                .MustAsync(async (dealerId, cancellation) => await dealersRepository.CheckIfDealerExists(dealerId))
                .WithMessage("Dealer not exists!");
        }
    }
}
