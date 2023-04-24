using Microsoft.QualityTools.Testing.Fakes;
using System.Reflection.Metadata.Ecma335;

namespace TddBank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2023, 4, 24, 10, 29, false)]//mo
        [InlineData(2023, 4, 24, 10, 30, true)]//mo
        [InlineData(2023, 4, 24, 10, 31, true)] //mo
        [InlineData(2023, 4, 24, 18, 59, true)] //mo
        [InlineData(2023, 4, 24, 19, 00, false)] //mo
        [InlineData(2023, 4, 29, 10, 30, true)] //sa
        [InlineData(2023, 4, 29, 16, 0, false)] //sa
        [InlineData(2023, 4, 29, 13, 0, true)] //sa
        [InlineData(2023, 4, 30, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(result, oh.IsOpen(dt));
        }

        [Fact]
        public void IsWeekend()
        {
            var oh = new OpeningHours();

            using var con = ShimsContext.Create();

            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 04, 24);
            Assert.False(oh.IsWeekend());//mo
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 04, 25);
            Assert.False(oh.IsWeekend());//di
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 04, 26);
            Assert.False(oh.IsWeekend());//mi
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 04, 27);
            Assert.False(oh.IsWeekend());//do
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 04, 28);
            Assert.False(oh.IsWeekend());//fr
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 04, 29);
            Assert.True(oh.IsWeekend());//sa
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 04, 30);
            Assert.True(oh.IsWeekend());//so

        }

        [Fact]
        public void IsKäseInConfig()
        {
            var oh = new OpeningHours();

            using var con = ShimsContext.Create();

            System.IO.Fakes.ShimFile.ReadAllTextString = (string path) => "🧀🧀🧀";

            Assert.True(oh.ReadConfigFile());
        }
    }
}
