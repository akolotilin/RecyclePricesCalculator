using Autofac;
using AutoMapper;
using CbrDailyInfo;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using VmsInform.Common.Behaviors;
using VmsInform.Common.Services;
using VmsInform.Common.TypeMapping;

namespace VmsInform.Common.DI
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(ThisAssembly);

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            builder.Register(ctx => new MapperConfiguration(cfg => AutomapperConfiguration.Configure(cfg, ctx)))
                .As<IConfigurationProvider>()
                .SingleInstance();

            builder.Register(ctx =>
            {
                var scope = ctx.Resolve<ILifetimeScope>();
                return new Mapper(ctx.Resolve<IConfigurationProvider>(), scope.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IService>()
                .AsImplementedInterfaces();

            builder.RegisterType<MappingConfiguration>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register(c => new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap))
                .InstancePerLifetimeScope()
                .AsSelf();
        }
    }
}
