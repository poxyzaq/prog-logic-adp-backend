namespace TabajaraCalc.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int totalOperations = 0;
            string[] opHistory = new string[100];

            Console.Clear();

            do
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("TabajaraCalc");
                Console.WriteLine("-----------------------");
                Console.WriteLine("(1) Sum");
                Console.WriteLine("(2) Subtract");
                Console.WriteLine("(3) Multiply");
                Console.WriteLine("(4) Divide");
                Console.WriteLine("(5) History");
                Console.WriteLine("(6) Mult table");
                Console.WriteLine("-----------------------");
                Console.WriteLine("(q) Quit");
                Console.WriteLine("-----------------------");
                Console.Write("> ");
                string menuChoice = Console.ReadLine();

                Console.Clear();

                if (menuChoice == "q")
                {
                    break;
                }

                if (!VerifyNumericInputs(menuChoice))
                {
                    Console.WriteLine("Invalid option. Try again..");
                    continue;
                }

                if (menuChoice == "5")
                {
                    if (totalOperations != 0)
                    {
                        Console.WriteLine("History");
                        Console.WriteLine("-------------------------------");
                        for (int index = 0; index < totalOperations; index++)
                        {
                            Console.WriteLine(opHistory[index]);
                        }
                        Console.WriteLine("-------------------------------");
                        Console.Write("Press any key to continue..");
                        Console.Read();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("The history is empty. Try again later..");
                    }
                    continue;
                }

                if (menuChoice == "6")
                {
                    int tabNumInt,
                        tabFromInt,
                        tabTillInt;

                    while (true)
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Multiplication table");
                        Console.WriteLine("-------------------------------");

                        Console.Write("Enter the number > ");
                        string tabNumStr = Console.ReadLine();
                        Console.WriteLine("------------------------------");

                        Console.Write("Calculate from number > ");
                        string tabFromStr = Console.ReadLine();
                        Console.WriteLine("------------------------------");

                        Console.Write("Calculate till number > ");
                        string tabTillStr = Console.ReadLine();

                        if (VerifyNumericInputs(tabNumStr, tabFromStr, tabTillStr))
                        {
                            tabNumInt = int.Parse(tabNumStr);
                            tabFromInt = int.Parse(tabFromStr);
                            tabTillInt = int.Parse(tabTillStr);

                            if (tabFromInt <= tabTillInt)
                            {
                                break;
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("Invalid numbers. Try again..");
                    }

                    Console.Clear();
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Multiplication table");
                    Console.WriteLine("-------------------------------");

                    for (int counter = tabFromInt; counter <= tabTillInt; counter++)
                    {
                        string tableString = $"{tabNumInt} x {counter} = {counter * tabNumInt}";
                        Console.WriteLine(tableString);
                    }

                    Console.WriteLine("-------------------------------");
                    Console.Write("Press any key to continue.. ");
                    Console.Read();
                    Console.Clear();
                    continue;
                }

                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Adding");
                        Console.WriteLine("-------------------------------");
                        break;
                    case "2":
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Subtracting");
                        Console.WriteLine("-------------------------------");
                        break;
                    case "3":
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Multiplying");
                        Console.WriteLine("-------------------------------");
                        break;
                    case "4":
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Dividing");
                        Console.WriteLine("-------------------------------");
                        break;
                }

                if (!AskForNumbersCalc(out double calcNum1, out double calcNum2))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid numbers. Try again..");
                    continue;
                }

                if (menuChoice == "4" && calcNum2 == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Dividing by zero is not possible. Try again..");
                    continue;
                }

                string opResult = Calculate(menuChoice, calcNum1, calcNum2);
                opHistory[totalOperations] = opResult;

                Console.WriteLine("-------------------------------");
                Console.WriteLine($"The result is {opResult}");
                Console.WriteLine("-------------------------------");
                Console.Write("Press any key to continue..");
                Console.Read();

                totalOperations++;
            } while (true);
        }

        static bool AskForNumbersCalc(out double calcNum1, out double calcNum2)
        {
            Console.Write("Enter the first number > ");
            string num1Str = Console.ReadLine();

            Console.WriteLine("-------------------------------");
            Console.Write("Enter the second number > ");
            string num2Str = Console.ReadLine();

            bool valid1 = double.TryParse(num1Str, out calcNum1);
            bool valid2 = double.TryParse(num2Str, out calcNum2);
            return valid1 && valid2;
        }

        static string Calculate(string op, double calcNum1, double calcNum2)
        {
            double result;
            string opString = null;

            switch (op)
            {
                case "1":
                    result = calcNum1 + calcNum2;
                    opString = $"{calcNum1} + {calcNum2} = {result}";
                    break;
                case "2":
                    result = calcNum1 - calcNum2;
                    opString = $"{calcNum1} - {calcNum2} = {result}";
                    break;
                case "3":
                    result = calcNum1 * calcNum2;
                    opString = $"{calcNum1} * {calcNum2} = {result}";
                    break;
                case "4":
                    result = calcNum1 / calcNum2;
                    opString = $"{calcNum1} / {calcNum2} = {result}";
                    break;
            }

            return opString;
        }

        static bool VerifyNumericInputs(string inp1, string inp2 = null, string inp3 = null)
        {
            if (!int.TryParse(inp1, out _))
            {
                return false;
            }

            if (inp2 is not null && !int.TryParse(inp2, out _))
            {
                return false;
            }

            if (inp3 is not null && !int.TryParse(inp3, out _))
            {
                return false;
            }

            return true;
        }
    }
}
