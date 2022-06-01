using System;

namespace VmsInform.Common.Services
{
    public interface IDateTimeService : IService
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
