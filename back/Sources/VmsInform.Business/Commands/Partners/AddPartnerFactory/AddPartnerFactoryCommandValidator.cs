using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Partners.AddPartnerFactory
{
    internal sealed class AddPartnerFactoryCommandValidator : AbstractValidator<AddPartnerFactoryCommand>
    {
        private readonly IVmsInformRepository<PartnerFactory> _partnerFactoryRepository;
        private readonly IVmsInformRepository<Factory> _factoryRepository;

        public AddPartnerFactoryCommandValidator(IVmsInformRepository<PartnerFactory> partnerFactoryRepository, IVmsInformRepository<Factory> factoryRepository)
        {
            _partnerFactoryRepository = partnerFactoryRepository ?? throw new ArgumentNullException(nameof(partnerFactoryRepository));
            _factoryRepository = factoryRepository ?? throw new ArgumentNullException(nameof(factoryRepository));

            RuleFor(a => a.FactoryId)
                .MustAsync(FactoryExists)
                .WithMessage("Factory does not exist");

            RuleFor(a => a)
                .MustAsync(FactoryShouldNotDuplicate)
                .WithMessage("Factory already added");
        }

        private async Task<bool> FactoryExists(long factoryId, CancellationToken cancellationToken)
        {
            return await _factoryRepository.Query().AnyAsync(a => a.Id == factoryId, cancellationToken);
        }

        public async Task<bool> FactoryShouldNotDuplicate(AddPartnerFactoryCommand command, CancellationToken cancellationToken)
        {
            return ! await _partnerFactoryRepository.Query()
                .AnyAsync(a => a.FactoryId == command.FactoryId && a.PartnerId == command.PartnerId, cancellationToken);
        }
    }
}
