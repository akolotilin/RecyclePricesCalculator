using Autofac;
using VmsInform.DAL;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInformWeb.DI
{
    public class DalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VmsInformUnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(VmsInformRepository<>))
                .As(typeof(IVmsInformRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<GlobalSettings>()
                .As<IGlobalSettings>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Transaction>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}
