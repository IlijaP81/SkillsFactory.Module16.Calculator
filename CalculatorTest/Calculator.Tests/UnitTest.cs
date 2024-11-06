using Moq;
using CalculatorToTest;

namespace Calculator.Tests
{
    [TestFixture]
    
    // set of unit tests
    public class CalculatorUnitTests
    {
        [Test]
        // method must return correct value as a result of Addition
        public void AdditionTest()
        {
            var calculator = new CalculatorToTest.Calculator();
            Assert.That(calculator.Addition(1, 1) == 2);
            Assert.False(calculator.Addition(1, 2) == 5);
            Assert.Greater(calculator.Addition(1, 2), calculator.Addition(1, 1));
        }

        [Test]
        // method must return correct value as a result of Subtraction
        public void SubtractionTest() 
        {

            var calculator = new CalculatorToTest.Calculator();
            Assert.That(calculator.Subtraction(2, 1) == 1);
            Assert.False(calculator.Subtraction(2,1) == 2);
        }
        
        [Test]
        // method must return correct value as a result of Miltiplication
        public void MiltiplicationTest()
        {
            var calculator = new CalculatorToTest.Calculator();
            Assert.That(calculator.Multiplication(3, 1) == 3);
            Assert.False(calculator.Multiplication(1, 0) == 1);
            Assert.Zero(calculator.Multiplication(1, 0));
        }
        
        [Test]
        // method must return correct value as a result of Division
        public void DivisionTest() 
        {
            var calculator = new CalculatorToTest.Calculator();
            Assert.That(calculator.Division(10, 2) == 5);
            Assert.False(calculator.Division(1, 1) == 2);
        }

        [Test]
        // method must throw DivideByZeroException
        public void DivisionByZeroTest()
        {
            var calculator = new CalculatorToTest.Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Division(1, 0));
        }
    }

    // set of Moq tests
    public class CalculatorMoqTest
    {
        [Test]
        public void CalculatorMoqTests()
        {
            var mockCalculator = new Mock<ICalculator>();
            mockCalculator.Setup(x => x.Addition(1,1)).Returns(2);
            mockCalculator.Setup(x => x.Subtraction(1,1)).Returns(0);
            mockCalculator.Setup(x => x.Multiplication(1,5)).Returns(5);
            mockCalculator.Setup(x => x.Division(6,2)).Returns(3);

            var mockCalculatorResultTest = new CalculatorToTest.Calculator(mockCalculator.Object);
            Assert.That(mockCalculatorResultTest.Multiplication(1, 5) == 5);
        }
    }

    public class CalculatorIntegrationTest
    {
        [Test]
        public void CalculatorIntegrationTests()
        {
            var testResult = new CalculatorToTest.Calculator();
            Assert.That(
                testResult.Multiplication(1,
                                            testResult.Addition(1,
                                                                  testResult.Subtraction(2,
                                                                                           testResult.Division(6, 3)
                        ))), Is.EqualTo(1));
        }
    }
}