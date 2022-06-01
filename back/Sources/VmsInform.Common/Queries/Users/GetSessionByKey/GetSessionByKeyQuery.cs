using MediatR;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Queries.Users.GetSessionByKey
{
    public class GetSessionByKeyQuery : IRequest<UserSessionDto>
    {
        public string Key { get; set; }
    }
}
