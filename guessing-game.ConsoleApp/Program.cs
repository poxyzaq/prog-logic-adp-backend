namespace guessing_name.ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            Console.Clear();

            do
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("| xXGUESSING-GAMEZZ | GOTY EDITION | v2.2334224551130987 |");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("(1) Lvl.1 Crook (10 lp, 20 range)");
                Console.WriteLine("(2) Lvl.10 Hitman (7 lp, 25 range)");
                Console.WriteLine("(3) Lvl.35 Mafia boss (4 lp, 30 range)");
                Console.WriteLine("----------------------------------------------------------");
                Console.Write("Choose a difficulty level > ");
                // true argument hides key input, but pointless because
                // i have to clear the console
                ConsoleKeyInfo gameDifficultyLevel = Console.ReadKey(true);

                int maxNumber,
                    totalLifes;

                Console.Clear();
                switch (gameDifficultyLevel.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        // numpad keys have to be checked
                        // independently
                        totalLifes = 10;
                        maxNumber = 20;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        totalLifes = 7;
                        maxNumber = 25;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        totalLifes = 4;
                        maxNumber = 30;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Invalid difficulty. Try again..");
                        continue;
                }

                int[] allGuesses = new int[totalLifes];
                int randomNum = RandomNumberGenerator.GetInt32(1, maxNumber + 1);
                int scorePoints = 1000;

                for (int lifes = totalLifes; lifes >= 0; lifes--)
                {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("| xXGUESSING-GAMEZZ | GOTY EDITION | v2.2334224551130987 |");
                    Console.WriteLine("----------------------------------------------------------");

                    if (lifes == 0)
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("You ran out of life points. Try again..");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"The number was {randomNum}!");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"Your final score > {scorePoints}");
                        break;
                    }

                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine($"Score points > {scorePoints}");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine($"Lifes remainining > {lifes}");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine($"Numbers range > {maxNumber}");
                    Console.WriteLine("----------------------------------------------------------");

                    // for debbuging purposes
                    //Console.WriteLine($">>>>>> {randomNum}");
                    //Console.WriteLine("----------------------------------------------------------");
                    Console.Write("Enter your guess > ");

                    if (!Int32.TryParse(Console.ReadLine(), out int playerGuess))
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Invalid input. Try again..");
                        Console.WriteLine("----------------------------------------------------------");

                        lifes++;
                        continue;
                    }

                    Console.Clear();
                    if (playerGuess < 1 || playerGuess > maxNumber)
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Out of range. Try again..");
                        Console.WriteLine("----------------------------------------------------------");

                        lifes++;
                        continue;
                    }

                    if (allGuesses.Contains(playerGuess))
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"You already guessed the number {playerGuess}. Try again..");
                        Console.WriteLine("----------------------------------------------------------");
                        lifes++;
                        continue;

                    }
                    else
                    {
                        int iterateAllGuesses = allGuesses.Length - lifes;
                        allGuesses[iterateAllGuesses] = playerGuess;
                    }

                    if (playerGuess == randomNum)
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("| xXGUESSING-GAMEZZ | GOTY EDITION | v2.2334224551130987 |");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"You got it! the number was {randomNum}");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"Your final score was {scorePoints}!");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                    }
                    else if (playerGuess > randomNum)
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"Nice try! but the number is smaller than {playerGuess}");
                        Console.WriteLine("----------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"Nice try! but the number is bigger than {playerGuess}");
                        Console.WriteLine("----------------------------------------------------------");
                    }

                    int numericDifference = Math.Abs(randomNum - playerGuess);

                    if (numericDifference >= 10)
                    {
                        scorePoints -= 100;
                    }
                    else if (numericDifference >= 5)
                    {
                        scorePoints -= 50;
                    }
                    else
                    {
                        scorePoints -= 20;
                    }
                }
                Console.WriteLine("----------------------------------------------------------");
                Console.Write("Press Return to continue > ");

                // while keypress is not enter, continue asking
                // true argument hides the pressed key on the screen
                // pointless because clear erases it
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("| xXGUESSING-GAMEZZ | GOTY EDITION | v2.2334224551130987 |");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Invalid input. Try again..");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.Write("Press Return to continue > ");
                }

                Console.Clear();

            } while (true);
        }
    }
}
