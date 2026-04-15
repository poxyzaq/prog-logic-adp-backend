
using System.Security.Cryptography;

namespace hangman_game;

class Program
{
    static void Main(string[] args)
    {
        string[] words =
        [
            "AVOCADO",
            "PINEAPPLE",
            "ACEROLA",
            "ACAI",
            "ARACA",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJA",
            "CASHEW",
            "STARFRUIT",
            "CUPUACU",
            "SOURSOP",
            "GUAVA",
            "JABUTICABA",
            "JENIPAPO",
            "APPLE",
            "MANGABA",
            "MANGO",
            "PASSIONFRUIT",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "DRAGONFRUIT",
            "SAPOTI",
            "TANGERINE",
            "UMBU",
            "GRAPE",
            "UVAIA"
        ];

        int randomIndex = RandomNumberGenerator.GetInt32(words.Length);

        string secretWord = words[randomIndex];

        char[] correctLetters = new char[secretWord.Length];

        for (int letterCounter = 0; letterCounter < secretWord.Length; letterCounter++)
        {
            correctLetters[letterCounter] = '_';
        }

        int errorCounter = 0;

        bool playerWon = false;
        bool playerLost = false;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hangman Game");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Errors: " + errorCounter);
            Console.Write("Guesses: ");

            for (int letterCounter = 0; letterCounter < secretWord.Length; letterCounter++)
            {
                Console.Write(correctLetters[letterCounter]);
            }

            Console.WriteLine("\n--------------------------------------------");

            if (errorCounter == 0)
            {
                Console.WriteLine(@" ___________        ");
                Console.WriteLine(@" |/        |        ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@"_|____              ");
            }
            else if (errorCounter == 1)
            {
                Console.WriteLine(@" ___________        ");
                Console.WriteLine(@" |/        |        ");
                Console.WriteLine(@" |         o        ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@"_|____              ");
            }
            else if (errorCounter == 2)
            {
                Console.WriteLine(@" ___________        ");
                Console.WriteLine(@" |/        |        ");
                Console.WriteLine(@" |         o        ");
                Console.WriteLine(@" |         |        ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@"_|____              ");
            }
            else if (errorCounter == 3)
            {
                Console.WriteLine(@" ___________        ");
                Console.WriteLine(@" |/        |        ");
                Console.WriteLine(@" |         o        ");
                Console.WriteLine(@" |        /|        ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@"_|____              ");
            }
            else if (errorCounter == 4)
            {
                Console.WriteLine(@" ___________        ");
                Console.WriteLine(@" |/        |        ");
                Console.WriteLine(@" |         o        ");
                Console.WriteLine(@" |        /|\       ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@"_|____              ");
            }
            else if (errorCounter == 5)
            {
                Console.WriteLine(@" ___________        ");
                Console.WriteLine(@" |/        |        ");
                Console.WriteLine(@" |         o        ");
                Console.WriteLine(@" |        /|\       ");
                Console.WriteLine(@" |        / \       ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@"_|____              ");
            }

            Console.WriteLine("\n--------------------------------------------");

            if (playerWon)
            {
                Console.WriteLine($"Congratulations, you won! The word was: {secretWord}");
                break;
            }
            else if (playerLost)
            {
                Console.WriteLine($"You lost! The word was: {secretWord}");
                break;
            }

            Console.Write("Enter a letter: ");
            char guess = Convert.ToChar(Console.ReadLine().ToUpper());

            bool letterFound = false;

            for (int secretWordCounter = 0; secretWordCounter < secretWord.Length; secretWordCounter++)
            {
                char currentSecretLetter = secretWord[secretWordCounter];

                if (guess == currentSecretLetter)
                {
                    correctLetters[secretWordCounter] = guess;
                    letterFound = true;
                }
            }

            if (!letterFound)
                errorCounter++;

            string correctLettersComplete = string.Join("", correctLetters);

            if (secretWord == correctLettersComplete)
                playerWon = true;

            if (errorCounter >= 5)
                playerLost = true;
        }

        Console.WriteLine("--------------------------------------------");
        Console.Write("Press ENTER to exit...");
        Console.ReadLine();
    }
}
