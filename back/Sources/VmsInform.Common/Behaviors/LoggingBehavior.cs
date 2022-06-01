using MediatR;
using Newtonsoft.Json;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInform.Common.Behaviors
{
    internal class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;

        public LoggingBehavior(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_logger.IsTraceEnabled)
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                _logger.Trace($"Handling {typeof(TRequest).Name}: {jsonRequest}");
            }

            try
            {
                var response = await next();

                if (_logger.IsTraceEnabled)
                {
                    var jsonResponse = JsonConvert.SerializeObject(response);
                    _logger.Trace($"Handled {typeof(TRequest).Name}: {jsonResponse}");
                }

                return response;
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
                throw;
            }
        }
    }
}
