using System;

namespace HumanNumbers
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    } 
}