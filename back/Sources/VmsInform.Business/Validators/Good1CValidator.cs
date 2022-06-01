using FluentValidation;
using System;
using System.Linq;
using VmsInform.Web.Dto.Goods._1C;

namespace VmsInform.Business.Validators
{
    internal sealed class Good1CValidator : AbstractValidator<Good1CDto>
    {
        public Good1CValidator(IValidator<Good1CSubItem> subItemValidator)
        {
            RuleFor(a => a.Code)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(a => a.Comment)
                .MaximumLength(1000);

            RuleFor(a => a.Guid)
                .NotEmpty();

            RuleFor(a => a.Guid)
                .Must(a => Guid.TryParse(a, out Guid guid))
                .WithMessage("Guid имеет неверный формат")
                .When(a => !string.IsNullOrEmpty(a.Guid));

            RuleForEach(a => a.SubItems)
                .SetValidator(subItemValidator)
                .When(a => a.SubItems?.Any() ?? false);
        }
    }
}
