using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using VmsInform.Business.DI;
using VmsInform.Common.DI;
using VmsInform.Common.Services.Impl;

namespace VmsInformWeb.DI
{
    public class WebAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(ThisAssembly);

            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.RegisterModule<BusinessModule>();
            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<LoggerModule>();

            builder.RegisterType<UserService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
