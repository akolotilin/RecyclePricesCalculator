using System;

namespace VmsInform.Common.Services.Impl
{
    internal sealed class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;

        public DateTime Today => DateTime.Today;
    }
}
