
namespace CalculatorToTest;

public class Calculator 
{
    // This constractor is for Unit tests
    public Calculator() { }
    
    // class Calculator is depended on interface ICalculator. This constractor is for Moq tests
    ICalculator calculator;
    public Calculator(ICalculator calculator)
    {  
        this.calculator = calculator; 
    }

    public int Addition(int a, int b)
    {
        return a + b;
    }

    public int Subtraction(int a, int b)
    {
        return a - b;
    }

    public int Multiplication(int a, int b)
    {
        return a * b;
    }

    public int Division(int a, int b)
    {
        return a / b;
    }
}