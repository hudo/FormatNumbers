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

            if(seconds < 60 * 60) // 1h
                return $"{Math.Floor(seconds / 60)} minutes ago";

            return "";
        }

        public static string FormatFromNow(DateTime fromDate)
        {
            return Format(SystemTime.Now() - fromDate);
        }
    }
}
