using System;

namespace Silkweb.Mobile.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string DaySuffix(this DateTime date)
        {
            switch (date.Day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }
    }
}

