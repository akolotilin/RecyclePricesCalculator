using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Services
{
    public interface IUserService
    {
        UserDto CurrentUser { get; }
    }
}
