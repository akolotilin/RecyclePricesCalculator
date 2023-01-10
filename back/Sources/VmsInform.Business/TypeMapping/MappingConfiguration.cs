using AutoMapper;
using System;
using VmsInform.Business.TypeMapping.Profiles;
using VmsInform.Common.Services;
using VmsInform.Common.TypeMapping;

namespace VmsInform.Business.TypeMapping
{
    internal sealed class MappingConfiguration : IAutomapperConfiguration
    {
        private readonly Func<IUserService> _userServiceFactory;

        public MappingConfiguration(Func<IUserService> userServiceFactory)
        {
            _userServiceFactory = userServiceFactory ?? throw new ArgumentNullException(nameof(userServiceFactory));
        }

        public void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<PartnersProfile>();
            configuration.AddProfile<PricesProfile>();
            configuration.AddProfile<GoodsProfile>();
            configuration.AddProfile<SettingsProfile>();
            configuration.AddProfile<DictionariesProfile>();
            configuration.AddProfile<ShipmentProfile>();
            configuration.AddProfile<FactoryProfile>();
            configuration.AddProfile(new NewsProfile(_userServiceFactory));
            configuration.AddProfile<ProductsProfile>();
        }
    }
}
