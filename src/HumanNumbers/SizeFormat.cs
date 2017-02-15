using System;
using static HumanNumbers.Helpers;
using static System.Math;

namespace HumanNumbers
{
    public class SizeFormat
    {
        public static string InKB(int bytes)
        {
            var size = (int)Math.Floor(bytes / 1024d);
            return $"{size} KB";
        }

        public static string InMB(int bytes)
        {
            var size = (int)Math.Floor(bytes / (1024 * 1024d));
            return $"{size} MB";
        }

        public static string InGB(int bytes)
        {
            var size = (int)Math.Floor(bytes / (1024 * 1024 * 1024d));
            return $"{size} GB";
        }

        public static string Readable(long bytes, NameOption names = null)
        {
            if(names == null) names = new NameOption();

            if (bytes < 1)
                return "empty";

            if (bytes < 1024)
                return $"{bytes} {Pluralize(bytes, names.Byte)}";

            if (bytes < 1024 * 1024)
                return $"{Floor(bytes / 1024d)} {names.KB}";

            if (bytes < 1024 * 1024 * 1024)
                return $"{Floor(bytes / (1024 * 1024d))} {names.MB}";

            if (bytes < unchecked(1024L * 1024 * 1024 * 1024))
                return $"{Floor(bytes / (1024 * 1024 * 1024d))} {names.GB}";

            try
            {
                return $"{Floor(bytes / (1024 * 1024 * 1024 * 1024d))} {names.TB}";
            }
            catch (Exception)
            {
                // fallback
                return $"gazillion {names.GB}";
            }
        }

        public class NameOption
        {
            public string Byte = "byte";
            public string KB = "KB";
            public string MB = "MB";
            public string GB = "GB";
            public string TB = "TB";
        }
    }
}
