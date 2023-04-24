using System.ComponentModel;

namespace Calculator.Tests_xUnit
{
    public class CalcTestsXUnit
    {
        [Fact]
        [Trait("", "UnitTest")]
        public void Sum_3_and_4_results_7_NUnit()
        {
            //Arrange
            Calc calc = new();

            //ActD
            var result = calc.Sum(3, 4);

            //Assert
            Assert.Equal(7, result);
        }

        [Theory]
        [Trait("", "UnitTest")]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        [InlineData(int.MaxValue - 5, 6)]
        public void Sum_overflow_should_throw(int a, int b)
        {
            Calc calc = new();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));
        }
    }
}