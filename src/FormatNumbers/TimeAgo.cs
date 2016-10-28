using System;

namespace FormatNumbers
{
    public class TimeAgo
    {
        public static string Format(TimeSpan span)
        {    
            var seconds = span.TotalSeconds;

            if(seconds < 5)
                return "just now";

            if(seconds < 60) // 1 min
                return $"{seconds} seconds ago";

            if(seconds < 3600) // 1h
            {
                var mins = Math.Floor(seconds / 60);
                return $"{mins} {Helpers.Pluralize((int)mins, "minute")} ago";
            }

            if(span.TotalMinutes < 1440) // 1 day
            {
                var hours = Math.Floor(span.TotalMinutes / 60);
                return $"{hours} hour{(hours == 1 ? "" : "s")} ago";
            }

            return "";
        }

        public static string FormatFromNow(DateTime fromDate)
        {
            return Format(SystemTime.Now() - fromDate);
        }
    }

}
