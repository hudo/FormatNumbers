using System.Text.RegularExpressions;
using HumanNumbers;
using Xunit;

namespace Tests
{
    public class SizeFormatTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(500)]
        [InlineData(1023)]
        public void Bytes(int bytes)
        {
            var text = SizeFormat.Readable(bytes);
            Assert.True(Regex.Match(text, @"^(\d){1,4} byte?").Success, text);
        }

        [Theory]
        [InlineData(1024)]
        [InlineData(5000)]
        [InlineData(1024 * 1024 - 1)]
        public void KiloBytes(int bytes)
        {
            var text = SizeFormat.Readable(bytes);
            Assert.True(Regex.Match(text, @"^(\d){1,4} KB").Success, text);
        }

        [Theory]
        [InlineData(1024)] // 1 MB
        [InlineData(5000)]
        [InlineData(1024 * 1024 - 1)]
        public void MegaBytes(long kilobytes)
        {
            var text = SizeFormat.Readable(kilobytes * 1024);
            Assert.True(Regex.Match(text, @"^(\d){1,4} MB").Success, text);
        }

        [Theory]
        [InlineData(1024)] // 1 GB
        [InlineData(5000)]
        [InlineData(1024 * 1024 - 1)]
        public void GigaBytes(long megabytes)
        {
            var text = SizeFormat.Readable(megabytes * 1024 * 1024);
            Assert.True(Regex.Match(text, @"^(\d){1,4} GB").Success, text);
        }

        [Fact]
        public void Can_change_unit_name()
        {
            var option = new SizeFormat.NameOption {Byte = "banana"};

            Assert.Equal("5 bananas", SizeFormat.Readable(5, option));
            Assert.Equal("1 banana", SizeFormat.Readable(1, option));
            Assert.Equal("2 KB", SizeFormat.Readable(2050, option));
        }
    }
}