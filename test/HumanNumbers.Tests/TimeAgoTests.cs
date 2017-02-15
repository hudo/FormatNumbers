using System;
using Xunit;
using HumanNumbers;
using static HumanNumbers.TimeFormat;

namespace Tests
{
    public class TimeAgoTests
    {
        public TimeAgoTests()
        {
            SystemTime.Now = () => new DateTime(2016, 1, 1, 12, 0, 0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        public void JustNow(int seconds) 
        {
            var text = Ago(TimeSpan.FromSeconds(seconds));
            Assert.Equal("just now", text);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(59)]
        public void SecondsAgo(int seconds) 
        {
            var text = Ago(TimeSpan.FromSeconds(seconds));
            Assert.Equal($"{seconds} seconds ago", text);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(59)]
        public void MinutesAgo(int mins) 
        {
            var text = Ago(TimeSpan.FromMinutes(mins));
            Assert.Equal(mins == 1 ? $"{mins} minute ago" : $"{mins} minutes ago", text);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(23)]
        public void HoursAgo(int hours) 
        {
            var text = Ago(TimeSpan.FromHours(hours));
            Assert.Equal(hours == 1 ? $"{hours} hour ago" : $"{hours} hours ago", text);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(20)]
        [InlineData(30)]
        public void DaysAgo(int days)
        {
            var text = Ago(TimeSpan.FromDays(days));
            Assert.Equal(days == 1 ? $"{days} day ago" : $"{days} days ago", text);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(11)]
        public void MonthsAgo(int months)
        {
            var text = Ago(TimeSpan.FromDays(months * 31));
            Assert.Equal(months == 1 ? $"{months} month ago" : $"{months} months ago", text);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void YearsAgo(int years)
        {
            var text = Ago(TimeSpan.FromDays(years * 365));
            Assert.Equal(years == 1 ? $"{years} year ago" : $"{years} years ago", text);
        }
    }
}

