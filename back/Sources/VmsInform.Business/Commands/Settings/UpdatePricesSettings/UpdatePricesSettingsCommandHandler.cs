using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.Web.Dto.Settings;

namespace VmsInform.Business.Commands.Settings.UpdatePricesSettings
{
    internal sealed class UpdatePricesSettingsCommandHandler : IRequestHandler<UpdatePricesSettingsCommand>
    {
        private readonly ITransaction _transaction;
        private readonly IGlobalSettings _globalSettings;
        private readonly IMapper _mapper;

        public UpdatePricesSettingsCommandHandler(ITransaction transaction, IGlobalSettings globalSettings, IMapper mapper)
        {
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
            _globalSettings = globalSettings ?? throw new ArgumentNullException(nameof(globalSettings));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdatePricesSettingsCommand request, CancellationToken cancellationToken)
        {
            using (var t = await _transaction.BeginAsync(cancellationToken))
            {
                _mapper.Map(request as PriceSettingsDto, _globalSettings);
                await t.CommitAsync();
            }

            return Unit.Value;
        }
    }
}
