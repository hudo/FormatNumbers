using System;
using Xunit;
using FormatNumbers;

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
            var text = FormatNumbers.TimeAgo.Format(TimeSpan.FromSeconds(seconds));
            Assert.Equal("just now", text);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(59)]
        public void SecondsAgo(int seconds) 
        {
            var text = FormatNumbers.TimeAgo.Format(TimeSpan.FromSeconds(seconds));
            Assert.Equal($"{seconds} seconds ago", text);
        }

        [Theory]
        [InlineData(60)]
        [InlineData(3599)]
        public void MinutesAgo(int seconds) 
        {
            var mins = Math.Floor(seconds / 60d);
            var text = FormatNumbers.TimeAgo.Format(TimeSpan.FromSeconds(seconds));
            Assert.Equal($"{mins} minutes ago", text);
        }
    }
}

