namespace guessing_name.ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            Console.Clear();

            do
            {
                int[] allGuesses;
                int randomNum,
                    maxNumber,
                    totalLifes;

                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Guessing game");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("(1) Lvl.1 Crook (10 lp, 20 range)");
                Console.WriteLine("(2) Lvl.10 Hitman (7 lp, 25 range)");
                Console.WriteLine("(3) Lvl.35 Mafia boss (5 lp, 30 range)");
                Console.WriteLine("------------------------------------------------");
                Console.Write("Choose a difficulty level > ");
                // true argument hides key input, but pointless because
                // i have to clear the console
                ConsoleKeyInfo gameDifficultyLevel = Console.ReadKey(true);
                Console.Clear();

                switch (gameDifficultyLevel.Key)
                {
                    case ConsoleKey.D1:
                        totalLifes = 10;
                        maxNumber = 20;
                        randomNum = RandomNumberGenerator.GetInt32(1, maxNumber);
                        break;

                    case ConsoleKey.D2:
                        totalLifes = 7;
                        maxNumber = 30;
                        randomNum = randomNum = RandomNumberGenerator.GetInt32(1, maxNumber);
                        break;

                    case ConsoleKey.D3:
                        totalLifes = 4;
                        maxNumber = 40;
                        randomNum = RandomNumberGenerator.GetInt32(1, maxNumber);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("Invalid difficulty. Try again..");
                        continue;
                }

                allGuesses = new int[totalLifes];

                for (int lifes = totalLifes; lifes >= 0; lifes--)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Guessing game");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Lifes remainining > {lifes}");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Numbers range > 1 - {maxNumber}");
                    Console.WriteLine("-------------------------------------");

                    // for debbuging purposes
                    Console.WriteLine($">>>>>> {randomNum}");
                    Console.WriteLine("------------------------------------------------");
                    Console.Write("Enter you guess > ");

                    if (!Int32.TryParse(Console.ReadLine(), out int playerGuess))
                    {
                        Console.Clear();
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("Invalid input. Try again..");
                        Console.WriteLine("------------------------------------------------");

                        lifes++;
                        continue;
                    }

                    Console.Clear();
                    if (playerGuess < 1 || playerGuess > maxNumber)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("Invalid range. Try again..");
                        Console.WriteLine("------------------------------------------------");

                        lifes++;
                        continue;
                    }


                    foreach (int number in allGuesses)
                    {
                        if (number == playerGuess)
                        {
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine($"You already guessed the number {number}. Try again..");
                            Console.WriteLine("------------------------------------------------");
                            lifes++;
                            continue;
                        }
                    }

                    int iterateAllGuesses = allGuesses.Length - lifes;
                    allGuesses[iterateAllGuesses] = playerGuess;

                    if (playerGuess == randomNum)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"You got it! the number was {randomNum}");
                        Console.WriteLine("------------------------------------------------");
                        break;
                    }

                    if (lifes == 1)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("You ran out of life points. Try again..");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"The number was {randomNum}!");
                        Console.WriteLine("------------------------------------------------");
                        break;
                    }
                    else if (playerGuess > randomNum)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Nice try! but the number is smaller than {playerGuess}");
                        Console.WriteLine("------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"Nice try! but the number is bigger than {playerGuess}");
                        Console.WriteLine("------------------------------------------------");
                    }
                }

                Console.WriteLine("Press Return to continue..");
                Console.WriteLine("-------------------------------------");

                // while keypress is not enter, continue asking
                // true argument hides the pressed key on the screen
                // pointless because clear erases it
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Invalid input. Try again..");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Press Return to continue..");
                    Console.WriteLine("-------------------------------------");
                }

                Console.Clear();

            } while (true);
        }
    }
}
