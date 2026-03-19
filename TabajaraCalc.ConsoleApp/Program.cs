namespace TabajaraCalc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userChoice;

            double num1,
                num2;

            double result = 0;

            Console.WriteLine("TabajaraCalc\n");
            Console.WriteLine("(1) Sum");
            Console.WriteLine("(2) Sub");
            Console.WriteLine("(3) Mult");
            Console.WriteLine("(4) Div");
            Console.WriteLine("(5) Hist");
            Console.WriteLine("(6) MTab\n");
            Console.WriteLine("(q) Quit");
            Console.Write("> ");
            userChoice = Console.ReadLine();

            if (userChoice == "q")
            {
                return;
            }

            Console.Write("Enter the first number > ");
            num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number > ");
            num2 = Convert.ToDouble(Console.ReadLine());

            switch (userChoice)
            {
                case "1":
                    result = num1 + num2;
                    break;

                case "2":
                    result = num1 - num2;
                    break;

                case "3":
                    result = num1 * num2;
                    break;

                case "4":
                    if (num2 != 0)
                    {
                        Console.WriteLine("Dividing by zero is not possible");
                        break;
                    }

                    result = num1 / num2;
                    break;

                default:
                    Console.WriteLine("Invalid option");

                    return;
            }

            Console.WriteLine($"The result is {result}");
        }
    }
}
