using System;

namespace VmsInform.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime WorkaroundFuckingTimeZone(this DateTime dateTime)
        {
            return dateTime.AddHours(12).Date;
        }
    }
}
