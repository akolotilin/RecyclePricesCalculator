using FluentValidation;
using System;
using System.Linq;
using VmsInform.Web.Dto.Goods._1C;

namespace VmsInform.Business.Validators
{
    internal sealed class Group1CDtoValidator : AbstractValidator<Group1CDto>
    {
        public Group1CDtoValidator(IValidator<Good1CDto> goodValidator)
        {
            RuleFor(a => a.Code)
                .MaximumLength(25);

            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(a => a.Guid)
                .NotEmpty();

            RuleFor(a => a.Guid)
                .Must(a => Guid.TryParse(a, out Guid guid))
                .WithMessage("Guid имеет неверный формат")
                .When(a => !string.IsNullOrEmpty(a.Guid));

            RuleFor(a => a.Goods)
                .NotEmpty()
                .When(a => !(a.SubGroups?.Any() ?? false));

            RuleForEach(a => a.Goods)
                .SetValidator(goodValidator);

            RuleForEach(a => a.SubGroups)
                .SetValidator(this);
        }
    }
}
