using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Queries.Partners.CountByTaxNumber
{
    internal sealed class CountByTaxNumberQueryHandler : IRequestHandler<CountByTaxNumberQuery, int>
    {
        private readonly IVmsInformRepository<Partner> _partnerRepository;

        public CountByTaxNumberQueryHandler(IVmsInformRepository<Partner> partnerRepository)
        {
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
        }

        public async Task<int> Handle(CountByTaxNumberQuery request, CancellationToken cancellationToken)
        {
            return await _partnerRepository.Query()
                .CountAsync(a => a.TaxNumber == request.TaxNumber, cancellationToken);
        }
    }
}
