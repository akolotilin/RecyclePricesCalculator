using FluentValidation;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Commands.Shipments.UpdateShipment
{
    internal sealed class UpdateShipmentCommandValidator : AbstractValidator<UpdateShipmentCommand>
    {
        public UpdateShipmentCommandValidator(IValidator<EditShipmentDto> validator)
        {
            RuleFor(a => a.Id)
                .GreaterThan(0);

            RuleFor(a => a.Shipment)
                .SetValidator(validator)
                .NotNull();
        }
    }
}
