using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        [TestCategory("Schulungstests")]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new();

            //ActD
            var result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);

        }

        [TestMethod]
        [TestCategory("Schulungstests")]
        public void Sum_100_and_500_results_600()
        {
            //Arrange
            Calc calc = new();

            //Act
            var result = calc.Sum(100, 500);

            //Assert
            Assert.AreEqual(600, result);
        }

        [TestMethod]
        [TestCategory("Schulungstests")]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Schulungstests")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            //Arrange
            Calc calc = new();

            //Act
            Action act = () => calc.Sum(int.MaxValue, 1);

            //Assert
            Assert.ThrowsException<OverflowException>(act);
        }

        [TestMethod]
        [TestCategory("Schulungstests")]
        public void Sum_MIN_and_n1_throws_OverflowException()
        {
            //Arrange
            Calc calc = new();

            //Act
            Action act = () => calc.Sum(int.MinValue, -1);

            //Assert
            Assert.ThrowsException<OverflowException>(act);
        }


        [TestMethod]
        [TestCategory("Unittest")] //RL
        [DataRow(0, 0, 0)]
        [DataRow(3, 4, 7)]
        [DataRow(-3, -4, -7)]
        [DataRow(-3, 4, 1)]
        [DataRow(3, -4, -1)]
        public void Sum_tests(int a, int b, int exp)
        {
            Calc calc = new();

            var result = calc.Sum(a, b);

            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        [TestCategory("Unittest")] //RL
        [DataRow(int.MaxValue, 1)]
        [DataRow(int.MinValue, -1)]
        [DataRow(int.MaxValue - 5, 6)]
        public void Sum_overflow_should_throw(int a, int b)
        {
            Calc calc = new();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(a, b));
        }

    }
}