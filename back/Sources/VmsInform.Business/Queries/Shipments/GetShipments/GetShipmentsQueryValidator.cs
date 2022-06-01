using FluentValidation;

namespace VmsInform.Business.Queries.Shipments.GetShipments
{
    internal sealed class GetShipmentsQueryValidator : AbstractValidator<GetShipmentsQuery>
    {
        public GetShipmentsQueryValidator()
        {
            RuleFor(a => a.DateFrom)
                .LessThan(a => a.DateTo)
                .When(a => a.DateFrom.HasValue && a.DateTo.HasValue);

        }
    }
}
