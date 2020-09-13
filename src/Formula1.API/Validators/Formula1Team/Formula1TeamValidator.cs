using BLL.Domain;
using FluentValidation;

namespace API.Validators.Formula1TeamValidator
{
    public class Formula1TeamValidator : AbstractValidator<Formula1Team>
    {
        public Formula1TeamValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Victories).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.IsFeePaid).NotNull();
        }
    }
}
