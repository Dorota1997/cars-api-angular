using car_themed_app.Commands.Dealers;
using FluentValidation;

namespace car_themed_app.Validators
{
    public class UpdateDealerCommandValidator : AbstractValidator<UpdateDealerCommand>
    {
        public UpdateDealerCommandValidator()
        {
            RuleFor(r => r.Dealer.Name)
                .Cascade(CascadeMode.Stop)
                .TextFieldValidation(5, 60);

            RuleFor(r => r.Dealer.Address)
                .Cascade(CascadeMode.Stop)
                .TextFieldValidation(2, 30);

            RuleFor(r => r.Dealer.PostalCode)
                .Cascade(CascadeMode.Stop)
                .TextFieldValidation(2, 15);

            RuleFor(r => r.Dealer.Country)
                .Cascade(CascadeMode.Stop)
                .TextFieldValidation(2, 20);
        }
    }
}
