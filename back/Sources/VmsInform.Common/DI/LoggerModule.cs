using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using NLog;
using System;
using System.Linq;

namespace VmsInform.Common.DI
{
    public sealed class LoggerModule : Module
    {
        //protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistry, IComponentRegistration registration)
        //{   
        //    registration.Preparing += (c, e) =>
        //    {
        //        var t = e.Component.Activator.LimitType;
        //        e.Parameters = e.Parameters.Union(
        //            new[]
        //            {
        //            new ResolvedParameter(
        //                (p, i) => p.ParameterType == typeof(ILogger),
        //                (p, i) => LogManager.GetLogger( GetLoggerName(t))),
        //            new ResolvedParameter((p, i) => p.ParameterType == typeof(Func<ILogger>),
        //                (p, i) => new Func<ILogger>(() => LogManager.GetLogger( GetLoggerName(t))))
        //            });
        //    };
        //}

        //private static string GetLoggerName(Type type)
        //{
        //    if (type.FullName.StartsWith("MediatR.IPipelineBehavior"))
        //        return "MediatR";

        //    if (type.FullName.Contains("EFLoggerFactory"))
        //        return "[DAL]";

        //    return type.FullName;
        //}
    }
}
