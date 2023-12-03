namespace homework1
{
    internal class Calculator
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to my fantastic calculator!");

            bool runCalculator = true;
            while (runCalculator)
            {
                Console.WriteLine("Select the operation you want to perform by entering the number:");
                Console.WriteLine("1 - addition");
                Console.WriteLine("2 - subtraction");
                Console.WriteLine("3 - multiplication");
                Console.WriteLine("4 - division");
                Console.WriteLine("5 - exponentiation");
                Console.WriteLine("6 - factorial");
                Console.WriteLine("Or type 'exit' to end the program.");

                var operationInput = Console.ReadLine();

                if (operationInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (!int.TryParse(operationInput, out int operation) || operation < 1 || operation > 6)
                {
                    Console.WriteLine("Invalid operation\n");
                    continue;
                }

                if (operation == 6)
                {
                    Console.WriteLine("Enter the number below:");
                }
                else
                {
                    Console.WriteLine("Enter the first number below:");
                }

                if (!double.TryParse(Console.ReadLine().Replace('.', ','), out double x))
                {
                    Console.WriteLine("Incorrect input.\n");
                    continue;
                }

                double y = 0;

                if (operation != 6)
                {
                    Console.WriteLine("Enter the second number below:");
                    if (!double.TryParse(Console.ReadLine().Replace('.', ','), out y))
                    {
                        Console.WriteLine("Incorrect input.\n");
                        continue;
                    }
                }

                if (!IsOperationValid(operation, x, y)) 
                {
                    continue;
                }

                double result = operation switch
                {
                    1 => Add(x, y),
                    2 => Subtract(x, y),
                    3 => Multiply(x, y),
                    4 => Divide(x, y),
                    5 => Power(x, y),
                    6 => Factorial(x)
                };

                Console.WriteLine($"Your result: {result}");

                Console.WriteLine("Type 'exit' to end the program or press enter to continue.");
                var exitInput = Console.ReadLine();
                runCalculator = !exitInput.Equals("exit", StringComparison.OrdinalIgnoreCase);
            }
            Console.WriteLine("Program ended. Goodbye!");
        }
        private static double Add(double x, double y) { return x + y; }
        private static double Subtract(double x, double y) { return x - y; }
        private static double Multiply(double x, double y) { return x * y; }
        private static double Divide(double x, double y) { return x / y; }
        private static double Power(double x, double y) { return Math.Pow(x, y); }
        private static double Factorial(double x)
        {
            if (x == 0)
                return 1;
            else
                return x * Factorial(x - 1);
        }

        private static bool IsOperationValid(int operation, double x, double y)
        {
            if (operation == 4 && y == 0)
            {
                Console.WriteLine("You cannot divide by zero!\n");
                return false;
            }

            if (operation == 5 && x < 0 && !(y == Math.Truncate(y)))
            {
                Console.WriteLine("You cannot calculate the non-integer power from a negative number!\n");
                return false;
            }

            if (operation == 6 && (x < 0 || !(x == Math.Truncate(x))))
            {
                Console.WriteLine("You cannot calculate the factorial of a negative or non-integer number!\n");
                return false;
            }
            return true;
        }
    }
}
