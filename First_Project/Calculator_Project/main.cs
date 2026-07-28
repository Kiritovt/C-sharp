using System;
using CalculatorApp;
public static class Calculator
{
    public static void Run(string[] args)
    {
        Operations operations = new Operations();
        List<string> history = new();
        bool continueProgram = true;

        while (continueProgram)
        {
            double a = ReadNumber("Enter the first number:");
            Console.WriteLine("Enter the operator (+, -, *, /, %):");
            string? op = Console.ReadLine();
            double b = ReadNumber("Enter the second number:");

            bool isValidOperator = op == "+" || op == "-" || op == "*" || op == "/" || op == "%";
            bool isDivisibleByZero = (op == "/" || op == "%") && b == 0;


            try
            {
                if (!isValidOperator)
                {
                    throw new InvalidOperationException("Invalid operator.");
                }
                else if (isDivisibleByZero)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }

            double result;

            switch (op)
            {
                case "+":
                    // Console.WriteLine("The result is: {operations.Sum(a, b)}");
                    result = operations.Sum(a, b);
                    break;

                case "-":
                    // Console.WriteLine("The result is: {operations.Subtract(a, b)}");
                    result = operations.Subtract(a, b);
                    break;

                case "*":
                    // Console.WriteLine("The result is: {operations.Multiply(a, b)}");
                    result = operations.Multiply(a, b);
                    break;

                case "/":
                    // Console.WriteLine("The result is: {operations.Divide(a, b)}");
                    result = operations.Divide(a, b);
                    break;
                case "%":
                    // Console.WriteLine("The result is: {operations.DivRest(a, b)}");
                    result = operations.DivRest(a, b);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operator.");
            }
            Console.WriteLine($"The result is: {result}");
            string historyEntry = $"{a} {op} {b} = {result}";
            history.Add(historyEntry);

            Console.WriteLine("Do u want to continue? (y/n)");
            string? continueChoice = Console.ReadLine().Trim().ToUpper();
            // if (continueChoice == "Y" || continueChoice == "YES")
            // {
            //     Main(args);
            // }
            // else
            // {
            //     Console.WriteLine("Goodbye!");

            if (continueChoice == "N" || continueChoice == "NO")
            {
                Console.WriteLine("Calculation History:");
                foreach (string entry in history)
                {
                    Console.WriteLine(entry);
                }

                Console.WriteLine("Goodbye!");
                continueProgram = false;
            } else if (continueChoice != "Y" && continueChoice != "YES")
            {
                Console.WriteLine("Invalid input. The calculator will continue.");
            }
        }
    }

    private static double ReadNumber(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
