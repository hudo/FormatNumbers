using System;
using static HumanNumbers.Helpers;
using static System.Math;

namespace HumanNumbers
{
    public class TimeFormat
    {
        public static string Ago(TimeSpan span)
        {    
            var seconds = span.TotalSeconds;

            if(seconds < 5)
                return "just now";

            if(seconds < 60) // 1 min
                return $"{seconds} seconds ago";

            if(seconds < 3600) // 1h
            {
                var mins = Floor(seconds / 60);
                return $"{mins} {Pluralize((int)mins, "minute")} ago";
            }

            if(span.TotalMinutes < 1440) // 1 day
            {
                var hours = Floor(span.TotalMinutes / 60);
                return $"{hours} {Pluralize((int)hours, "hour")} ago";
            }

            if (span.TotalDays < 31)
            {
                return $"{span.TotalDays} {Pluralize((int) span.TotalDays, "day")} ago";
            }

            if (span.TotalDays < 365) // 1 year
            {
                var months = Floor(span.TotalDays / 30);
                return $"{months} {Pluralize((int) months, "month")} ago";
            }

            var years = Floor(span.TotalDays / 365);
            return $"{years} {Pluralize((int) years, "year")} ago";
        }

        public static string Ago(DateTime fromDate)
        {
            return Ago(SystemTime.Now() - fromDate);
        }
    }

}
