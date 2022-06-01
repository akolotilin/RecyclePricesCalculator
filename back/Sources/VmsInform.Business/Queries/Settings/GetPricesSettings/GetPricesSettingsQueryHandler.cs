using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.Web.Dto.Settings;

namespace VmsInform.Business.Queries.Settings.GetPricesSettings
{
    internal sealed class GetPricesSettingsQueryHandler : IRequestHandler<GetPricesSettingsQuery, PriceSettingsDto>
    {
        private readonly IGlobalSettings _globalSettings;
        private readonly IMapper _mapper;

        public GetPricesSettingsQueryHandler(IGlobalSettings globalSettings, IMapper mapper)
        {
            _globalSettings = globalSettings;
            _mapper = mapper;
        }

        public Task<PriceSettingsDto> Handle(GetPricesSettingsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<PriceSettingsDto>(_globalSettings));
        }
    }
}
