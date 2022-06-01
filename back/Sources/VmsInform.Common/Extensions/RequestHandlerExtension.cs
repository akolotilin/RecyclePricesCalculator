using MediatR;
using VmsInform.Common.Exceptions;

namespace VmsInform.Common.Extensions
{
    public static class RequestHandlerExtension
    {
        public static void ThrowNotFoundIfNull<T, TResult>(this IRequestHandler<T, TResult> handler, object itemToCheck, string message)
            where T: IRequest<TResult>
        {
            if (itemToCheck == null)
                throw new NotFoundException(message);
        }
    }
}
