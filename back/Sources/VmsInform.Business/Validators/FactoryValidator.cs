using FluentValidation;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Validators
{
    internal sealed class FactoryValidator : AbstractValidator<FactoryDto>
    {
        public FactoryValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(a => a.Address)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(a => a.MinGarbage)
                .LessThanOrEqualTo(a => a.MinGarbage);
        }
    }
}
