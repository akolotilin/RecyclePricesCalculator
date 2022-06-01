using Autofac;
using AutoMapper;
using FluentValidation;
using MediatR.Extensions.Autofac.DependencyInjection;
using VmsInform.Business.TypeMapping;
using VmsInform.Common.Extensions;
using VmsInform.Common.Services;
using VmsInform.Common.TypeMapping;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.DI
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(ThisAssembly);

            builder.RegisterType<MappingConfiguration>()
                .As<IAutomapperConfiguration>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IValueResolver<,,>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IService>()
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            builder.AddDictionary<Currency>();
        }
    }
}
