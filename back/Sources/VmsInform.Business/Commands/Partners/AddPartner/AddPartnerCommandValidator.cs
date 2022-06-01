using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Queries.Partners.FindByTaxNumber;

namespace VmsInform.Business.Commands.Partners.AddPartner
{
    internal sealed class AddPartnerCommandValidator : AbstractValidator<AddPartnerCommand>
    {
        private readonly IMediator _mediator;

        public AddPartnerCommandValidator(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            RuleFor(a => a.Name)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(a => a.Address)
                .MaximumLength(500)
                .NotEmpty();

            RuleFor(a => a.TaxNumber)
                .MaximumLength(12);

            RuleFor(a => a)
                .MustAsync(CheckTaxNumber)
                .WithMessage("ИНН партнера не уникальный")
                .WithName(nameof(AddPartnerCommand.TaxNumber))
                .When(a => !string.IsNullOrEmpty(a.TaxNumber));
        }

        private async Task<bool> CheckTaxNumber(AddPartnerCommand command, CancellationToken cancellationToken)
        {
            var partner = await _mediator.Send(new FindByTaxNumberQuery { TaxNumber = command.TaxNumber }, cancellationToken);
            return partner == null;
        }
    }
}
