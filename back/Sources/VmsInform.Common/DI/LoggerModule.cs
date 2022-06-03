using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Core.Resolving.Pipeline;
using NLog;
using System;
using System.Linq;

namespace VmsInform.Common.DI
{
    internal sealed class LoggerResolveMiddleware : IResolveMiddleware
    {
        public PipelinePhase Phase => PipelinePhase.ParameterSelection;

        public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
        {
            context.ChangeParameters(context.Parameters.Union(
                    new[]
                    {
                    new ResolvedParameter(
                        (p, i) => p.ParameterType == typeof(ILogger),
                        (p, i) => LogManager.GetLogger( GetLoggerName(context.Registration.Activator.LimitType))),
                    new ResolvedParameter((p, i) => p.ParameterType == typeof(Func<ILogger>),
                        (p, i) => new Func<ILogger>(() => LogManager.GetLogger( GetLoggerName(context.Registration.Activator.LimitType))))
                    }));

            next(context);
        }

        private static string GetLoggerName(Type type)
        {
            if (type.FullName.StartsWith("MediatR.IPipelineBehavior"))
                return "MediatR";

            if (type.FullName.Contains("EFLoggerFactory"))
                return "[DAL]";

            return type.FullName;
        }
    }

    public sealed class LoggerModule : Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistry, IComponentRegistration registration)
        {
            registration.ConfigurePipeline(builder => builder.Use(new LoggerResolveMiddleware()));
        }
    }
}
