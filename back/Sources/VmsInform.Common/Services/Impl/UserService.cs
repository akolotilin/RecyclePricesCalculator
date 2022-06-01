using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Services.Impl
{
    internal sealed class UserService : IUserService, IService
    {
        public UserService(IHttpContextAccessor httpContextAccessor)
        {

        }

        public UserDto CurrentUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
