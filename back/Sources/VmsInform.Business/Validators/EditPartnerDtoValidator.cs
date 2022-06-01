using FluentValidation;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Validators
{
    internal sealed class EditPartnerDtoValidator : AbstractValidator<EditPartnerDto>
    {
        public EditPartnerDtoValidator()
        {
            RuleFor(a => a.Name)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(a => a.Address)
                .MaximumLength(500)
                .NotEmpty();

            RuleFor(a => a.Comment)
                .MaximumLength(1000);

            RuleFor(a => a.TaxNumber)
                .MaximumLength(12);
        }
    }
}
