using Autofac;
using VmsInform.Common.Queries.Common.GetDictionary;
using VmsInform.DAL.Domain;

namespace VmsInform.Common.Extensions
{
    public static class ContainerBuilderExtension
    {
        public static void AddDictionary<TDictionary>(this ContainerBuilder containerBuilder)
            where TDictionary : NamedObject
        {
            containerBuilder.RegisterType<GetDictionaryQueryHandler<TDictionary>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
