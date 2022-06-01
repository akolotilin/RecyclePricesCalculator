using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using VmsInform.Common.Queries.Users.GetSessionByKey;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Services.Impl
{
    internal sealed class UserService : IUserService, IService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public UserService(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public UserDto CurrentUser
        {
            get
            {
                var authKey = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                var session = _mediator.Send(new GetSessionByKeyQuery { Key = authKey }).Result;
                return session?.User;
            }
        }
    }
}
