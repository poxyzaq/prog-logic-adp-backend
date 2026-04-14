namespace dice_racing_game;

using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Menu();
    }

    static void Menu()
    {
        do
        {
            string userChoice;

            Console.WriteLine("---");
            Console.WriteLine("==============================");
            Console.WriteLine("Dice racing game (v3.14159265)");
            Console.WriteLine("==============================");
            Console.WriteLine("(1) Start\n");
            Console.WriteLine("(q) Quit");
            Console.WriteLine("==============================");
            Console.WriteLine("---");
            Console.Write("> ");
            userChoice = Console.ReadLine().ToUpper();

            Console.Clear();

            if (userChoice == "q")
            {
                Environment.Exit(1);
            }

            if (userChoice == "1")
            {
                StartGame();
            }

        } while (true);
    }

    static void StartGame()
    {
        string[][] board;
        string[][] upBoard;
        int diceNumber;
        int prevPlayerPos = 0;
        int prevCpuPos = 0;
        int playerPos = 0;
        int cpuPos = 0;
        bool isPlayerTurn;
        bool isGameFinished;

        board = PopulateBoard();
        isPlayerTurn = true;

        do
        {
            diceNumber = RollDice(isPlayerTurn);
            MoveDice(ref diceNumber, ref playerPos, ref prevPlayerPos,
                     ref cpuPos, ref prevCpuPos, ref isPlayerTurn);

            EventChecker(ref playerPos, ref cpuPos, ref diceNumber,
                         ref isPlayerTurn);
            
            //playerPos = 30;
            isGameFinished = WinnerChecker(playerPos, cpuPos);
            //isGameFinished = true;
            if (isGameFinished) break;

            upBoard = UpdateBoard(board, playerPos, prevPlayerPos,
                                  cpuPos, prevCpuPos);
            LogBoard(upBoard, ref playerPos, ref prevPlayerPos,
                     ref cpuPos, ref prevCpuPos);

        } while (true);
    }

    static string[][] PopulateBoard()
    {
        int boardSize = 2;
        int pathSize = 30;
        string defaultValue = "_";

        string[] playerPath = new string[pathSize];
        string[] cpuPath = new string[pathSize];

        string[][] board = { playerPath, cpuPath };

        for (int path = 0; path < boardSize; path++)
        {
            for (int pos = 0; pos < pathSize; pos++)
            {
                board[path][pos] = defaultValue;
            }
        }

        board[0][0] = "*";
        board[1][0] = "+";

        return board;
    }

    static void LogBoard(string[][] board, ref int playerPos,
                         ref int prevPlayerPos, ref int cpuPos,
                         ref int prevCpuPos)
    {

        Console.WriteLine($"(Player) {prevPlayerPos} -> {playerPos}");
        Console.WriteLine($"(Cpu) {prevCpuPos} -> {cpuPos}");
        Console.WriteLine("---");
        Console.WriteLine("==============================");
        Console.WriteLine("            Board             ");
        Console.WriteLine("==============================");

        for (int path = 0; path < board.Length; path++)
        {
            for (int pos = 0; pos < board[path].Length; pos++)
            {
                Console.Write($"{board[path][pos]}");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("==============================");
        Console.WriteLine("---");
        Console.Write("Press any key to continue..");
        Console.ReadLine();
        Console.Clear();
    }

    static string[][] UpdateBoard(string[][] board, int playerPos, 
                                  int prevPlayerPos, int cpuPos,
                                  int prevCpuPos)
    {
        if (playerPos != prevPlayerPos)
        {
            board[0][prevPlayerPos] = "_";
            board[0][playerPos] = "*";
        }

        if (cpuPos != prevCpuPos)
        {
            board[1][prevCpuPos] = "_";
            board[1][cpuPos] = "+";
        }

        return board;
    }

    static int RollDice(bool isPlayerTurn)
    {
        string whowhowho;
        Random random = new();
        int randomNum;

        Console.WriteLine("---");
        if (isPlayerTurn)
        {
            whowhowho = "Player";
            Console.WriteLine("Player turn!");
            Console.Write("Press any key to roll the dice..");
            Console.ReadLine();
            Console.WriteLine("---");
            Console.Write("Rolling");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(400);
                Console.Write(".");
            }

            randomNum = random.Next(1, 7);
        }
        else
        {
            whowhowho = "Cpu";
            Console.WriteLine("Cpu Turn!");
            Console.WriteLine("---");
            Console.Write("Rolling");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }

            randomNum = random.Next(1, 7);
        }

        Console.WriteLine();
        Console.WriteLine($"{whowhowho} rolled the number {randomNum}");
        Console.WriteLine("---");
        return randomNum;
    }

    static void MoveDice(ref int diceNumber, ref int playerPos,
                         ref int prevPlayerPos, ref int cpuPos,
                         ref int prevCpuPos, ref bool isPlayerTurn)
    {
        if (isPlayerTurn)
        {
            prevPlayerPos = playerPos;
            playerPos += diceNumber;
        }
        else
        {
            prevCpuPos = cpuPos;
            cpuPos += diceNumber;
        }
    }

    static void EventChecker(ref int playerPos, ref int cpuPos,
                             ref int diceNumber, ref bool isPlayerTurn)
    {
        int[] extraMoveSquares = { 5, 10, 15 };
        int extraMove = 3;
        int[] moveBackSquares = { 7, 13, 20 };
        int moveBack = 2;
        int extraRoundRoll = 6;

        if (isPlayerTurn)
        {
            if (extraMoveSquares.Contains(playerPos))
            {
                Console.WriteLine($"Player hit square {playerPos}. Stepping {extraMove}");
                playerPos += extraMove;
            }
            
            if (moveBackSquares.Contains(playerPos))
            {
                Console.WriteLine($"Player hit square {playerPos}. Backing {moveBack}");
                playerPos -= moveBack;
            }

            if (diceNumber == extraRoundRoll)
            {
                Console.WriteLine($"Player rolled {extraRoundRoll}. Running extra round!");
            }
            else
            {
                isPlayerTurn = !isPlayerTurn;
            }
        }
        else
        {
            if (extraMoveSquares.Contains(cpuPos))
            {
                Console.WriteLine($"Cpu hit square {cpuPos}. Stepping {extraMove}");
                cpuPos += extraMove;
            }
            
            if (moveBackSquares.Contains(cpuPos))
            {
                Console.WriteLine($"Cpu hit square {cpuPos}. Backing {moveBack}");
                cpuPos -= moveBack;
            }

            if (diceNumber == extraRoundRoll)
            {
                Console.WriteLine($"Cpu rolled {extraRoundRoll}. Running extra round!");
            }
            else
            {
                isPlayerTurn = !isPlayerTurn;
            }
        }

        Console.WriteLine("---");
    }

    static bool WinnerChecker(int playerPos, int cpuPos)
    {
        if (playerPos >= 30)
        {
            Console.WriteLine("Player won!");
            return true;
        }

        if (cpuPos >= 30)
        {
            Console.WriteLine("Cpu won!");
            return true;
        }
    
        return false;
    }
}
