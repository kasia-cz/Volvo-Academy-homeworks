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

                // TO DO: try parse x, y

                var x = int.Parse(Console.ReadLine());

                var y = 0;

                if (operation != 6)
                {
                    Console.WriteLine("Enter the second number below:");
                    y = int.Parse(Console.ReadLine());
                }

                if (operation == 4 && y == 0)
                {
                    Console.WriteLine("You cannot divide by zero!\n");
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
        private static int Add(int x, int y) { return x + y; }
        private static int Subtract(int x, int y) { return x - y; }
        private static int Multiply(int x, int y) { return x * y; }
        private static double Divide(int x, int y) { return x / y; }
        private static double Power(int x, int y) { return Math.Pow(x, y); }
        private static int Factorial(int x)
        {
            if (x == 0)
                return 1;
            else
                return x * Factorial(x - 1);
        }
    }
}
