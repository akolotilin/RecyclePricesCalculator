using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Partners.RemovePartnerFactory
{
    internal class RemovePartnerFactoryCommandHandler : IRequestHandler<RemovePartnerFactoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Partner> _partnersRepository;

        public RemovePartnerFactoryCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Partner> partnersRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _partnersRepository = partnersRepository ?? throw new ArgumentNullException(nameof(partnersRepository));
        }

        public async Task<Unit> Handle(RemovePartnerFactoryCommand request, CancellationToken cancellationToken)
        {
            var partner = await _partnersRepository.Query()
                .Include(a => a.Factories)
                .FirstOrDefaultAsync(a => a.Id == request.PartnerId, cancellationToken);

            if (partner == null)
                throw new NotFoundException("Partner not found");

            partner.Factories
                .Where(a => a.FactoryId == request.FactoryId)
                .ToList()
                .ForEach(a => partner.Factories.Remove(a));

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
