using FluentValidation;
using System;
using VmsInform.Web.Dto.Goods._1C;

namespace VmsInform.Business.Validators
{
    internal sealed class Good1CSubItemValidator : AbstractValidator<Good1CSubItem>
    {
        public Good1CSubItemValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(a => a.Guid)
                .NotEmpty();

            RuleFor(a => a.Guid)
                .Must(a => Guid.TryParse(a, out Guid guid))
                .WithMessage("Guid имеет неверный формат")
                .When(a => !string.IsNullOrEmpty(a.Guid));
        }
    }
}
