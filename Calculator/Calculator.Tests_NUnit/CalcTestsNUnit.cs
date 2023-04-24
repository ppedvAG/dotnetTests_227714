namespace Calculator.Tests_NUnit
{
    public class CalcTests
    {
        [Test]
        [Category("Unittest")]
        public void Sum_3_and_4_results_7_NUnit()
        {
            //Arrange
            Calc calc = new();

            //ActD
            var result = calc.Sum(3, 4);

            //Assert
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        [Category("Unittest")] //RL
        [TestCase(int.MaxValue, 1)]
        [TestCase(int.MinValue, -1)]
        [TestCase(int.MaxValue - 5, 6)]
        public void Sum_overflow_should_throw(int a, int b)
        {
            Calc calc = new();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));
        }
    }
}