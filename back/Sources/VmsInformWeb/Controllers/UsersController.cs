using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VmsInform.Common.Commands.ChangePasswordByRequest;
using VmsInform.Common.Commands.RestorePassword;
using VmsInform.Common.Commands.Users.AddUser;
using VmsInform.Common.Commands.Users.AuthUser;
using VmsInform.Common.Commands.Users.ChangePassword;
using VmsInform.Common.Commands.Users.UpdateUser;
using VmsInform.Common.Queries.Users;
using VmsInform.Common.Queries.Users.GetUsers;
using VmsInform.Web.Dto.Users;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] AuthUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }

        [HttpPost("restorePassword/{EMail}")]
        public async Task<ActionResult> RestorePassword([FromRoute] RestorePasswordCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("checkRestorePasswordRequest")]
        public async Task<CheckPasswordChangeRequestResultDto> CheckRestorePasswordRequest([FromQuery] CheckPasswordChangeRequestQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("changePasswordByRequest")]
        public async Task ChangePasswordByRequest(ChangePasswordByRequestCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet("users")]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }

        [HttpPost("users/update")]
        public async Task<UserDto> UpdateUser([FromBody] UserDto user)
        {
            return await _mediator.Send(new UpdateUserCommand { User = user });
        }

        [HttpPost("add")]
        public async Task<UserDto> AddUser([FromBody] AddUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("changePassword")]
        public async Task ChangePassword([FromBody] ChangePasswordCommand command)
        {
            await _mediator.Send(command);
        }
    }
}