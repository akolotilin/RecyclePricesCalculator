using System;

namespace VmsInform.DAL.Domain.Common
{
    public interface IEditorInfo
    {
        long LastEditorId { get; set; }
        User LastEditor { get; set; }

        DateTime LastEdit { get; set; }

        long CreatorId { get; set; }
        User Creator { get; set; }

        DateTime Created { get; set; }
    }
}
