using FluentValidation;

namespace VmsInform.Business.Commands.Shipments.AddShipment
{
    internal sealed class AddShipmentCommandValidator : AbstractValidator<AddShipmentCommand>
    {
        public AddShipmentCommandValidator()
        {
            RuleFor(a => a.PartnerId)
                .NotNull();
        }
    }
}
