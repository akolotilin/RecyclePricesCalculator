using Autofac;
using AutoMapper;

namespace VmsInform.Common.TypeMapping
{
    internal static class AutomapperConfiguration
    {
        public static void Configure(IMapperConfigurationExpression configuration, IComponentContext componentContext)
        {
            var configurations = componentContext.Resolve<IAutomapperConfiguration[]>();
            foreach (var conf in configurations)
            {
                conf.Configure(configuration);
            }
            configuration.ConstructServicesUsing(componentContext.Resolve);
        }
    }
}
