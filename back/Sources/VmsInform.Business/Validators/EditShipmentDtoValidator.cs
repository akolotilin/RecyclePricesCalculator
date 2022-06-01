using FluentValidation;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Validators
{
    internal class EditShipmentDtoValidator : AbstractValidator<EditShipmentDto>
    {
        public EditShipmentDtoValidator()
        {
            RuleFor(a => a.ShipmentDate)
                .NotNull();

            RuleFor(a => a.PartnerId)
                .GreaterThan(0);

            RuleFor(a => a.FactoryId)
                .GreaterThan(0);

        }
    }
}
