/* There are at least seven logic errors in this code and many bad design choices. 
    Feel free to comment or directly edit your changes but do not merge your branch with main! */ 

using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator");

        try
        {
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select operation (+, -, *, /): ");
            char operation = Console.ReadLine()[0];
            
            int result = CalculatorLogic.PerformCalculation(num1, num2, operation);

            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

class CalculatorLogic
{
    public static int PerformCalculation(int num1, int num2, char operation)
    {
        int result = 0;

        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                // *
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    throw new DivideByZeroException("Error: Division by zero.");
                }
                break;
            default:
                throw new InvalidOperationException("Error: Invalid operation selected.");
        }
        return result;
    }
}