using System;
using VmsInform.Common.Services;
using VmsInform.DAL.Domain.Common;

namespace VmsInform.Business.Services.Impl
{
    internal sealed class AuthorService : IAuthorService, IService
    {
        private readonly IUserService _userService;
        private readonly IDateTimeService _dateTimeService;

        public AuthorService(IUserService userService, IDateTimeService dateTimeService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public void SetupCreator(IEditorInfo editorInfo)
        {
            var user = _userService.CurrentUser;

            editorInfo.CreatorId = editorInfo.LastEditorId = user.Id;
            editorInfo.Created  = editorInfo.LastEdit = _dateTimeService.Now;
        }

        public void SetupEditor(IEditorInfo editorInfo)
        {
            var user = _userService.CurrentUser;

            editorInfo.LastEditorId = user.Id;
            editorInfo.LastEdit = _dateTimeService.Now;
        }
    }
}
