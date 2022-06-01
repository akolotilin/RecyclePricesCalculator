using AutoMapper;
using CbrDailyInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Common.Services.Impl
{
    internal sealed class CurrencyService : ICurrencyService, IService
    {
        private readonly DailyInfoSoapClient _dailyInfoClient;
        private readonly IDateTimeService _dateTimeService;
        private readonly IVmsInformRepository<Currency> _currencyRepository;
        private readonly IMapper _mapper;

        IDictionary<string, decimal> _cources = new Dictionary<string, decimal>();

        public CurrencyService(DailyInfoSoapClient dailyInfoClient, IDateTimeService dateTimeService, 
            IVmsInformRepository<Currency> currencyRepository, IMapper mapper)
        {
            _dailyInfoClient = dailyInfoClient ?? throw new ArgumentNullException(nameof(dailyInfoClient));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<decimal> GetCource(string currencyCode)
        {
            if (!_cources.Any())
            {
                var client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
                await client.OpenAsync();

                var courceData = await client.GetCursOnDateXMLAsync(_dateTimeService.Today);

                var dataSet = new DataSet();
                dataSet.ReadXml(courceData.CreateReader());

                var courceTable = dataSet.Tables["ValuteCursOnDate"];

                foreach (DataRow row in courceTable.Rows)
                {
                    _cources.Add(row["VchCode"].ToString(), decimal.Parse(row["Vcurs"].ToString(), System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            return _cources[currencyCode];
        }

        public async Task<CurrencyDto> GetCurrencyByCode(string code, CancellationToken cancellationToken = default)
        {
            var currency = await _currencyRepository.Query()
                .FirstOrDefaultAsync(a => a.Code == code, cancellationToken);

            return _mapper.Map<CurrencyDto>(currency);
        }
    }
}
