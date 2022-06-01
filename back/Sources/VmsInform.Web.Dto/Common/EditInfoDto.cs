using System;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Web.Dto.Common
{
    public class EditInfoDto
    {
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        public UserDto Creator { get; set; }
        public UserDto LastEditor { get; set; }
    }
}
