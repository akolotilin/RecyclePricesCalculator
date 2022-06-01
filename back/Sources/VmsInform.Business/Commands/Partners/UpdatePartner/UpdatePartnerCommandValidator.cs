using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Queries.Partners.FindByTaxNumber;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.UpdatePartner
{
    internal sealed class UpdatePartnerCommandValidator : AbstractValidator<UpdatePartnerCommand>
    {
        private readonly IMediator _mediator;

        public UpdatePartnerCommandValidator(IValidator<EditPartnerDto> partnerValidator, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            RuleFor(a => a.Partner)
                .NotNull()
                .SetValidator(partnerValidator);

            RuleFor(a => a.PartnerId)
                .GreaterThan(0);

            RuleFor(a => a)
                .MustAsync(CheckTaxNumber)
                .WithMessage("ИНН партнера не уникальный")
                .WithName(nameof(EditPartnerDto.TaxNumber))
                .When(a => !string.IsNullOrEmpty(a.Partner?.TaxNumber));
        }

        private async Task<bool> CheckTaxNumber(UpdatePartnerCommand command, CancellationToken cancellationToken)
        {
            var partner = await _mediator.Send(new FindByTaxNumberQuery { TaxNumber = command.Partner.TaxNumber }, cancellationToken);
            return partner == null || partner.Id == command.PartnerId;
        }
    }
}
