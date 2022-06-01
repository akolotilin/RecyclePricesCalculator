using AutoMapper;
using VmsInform.Common.TypeMapping.Profiles;

namespace VmsInform.Common.TypeMapping
{
    internal sealed class MappingConfiguration : IAutomapperConfiguration
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<CommonProfile>();
            configuration.AddProfile<UsersProfile>();
            configuration.AddProfile<NotificationProfile>();
        }
    }
}
