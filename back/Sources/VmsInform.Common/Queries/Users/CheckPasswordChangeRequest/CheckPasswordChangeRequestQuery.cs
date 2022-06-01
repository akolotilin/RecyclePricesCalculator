using MediatR;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Queries.Users
{
    public class CheckPasswordChangeRequestQuery : IRequest<CheckPasswordChangeRequestResultDto>
    {
        public string Key { get; set; }
    }
}
