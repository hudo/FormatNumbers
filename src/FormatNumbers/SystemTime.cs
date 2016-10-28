using System;

namespace FormatNumbers
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    } 
}