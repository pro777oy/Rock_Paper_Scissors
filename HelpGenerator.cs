namespace Rock_Paper_Scissors;

    public static class HelpGenerator
    {
        public static void DisplayHelpTable(string[] moves)
        {
            var totalMoves = moves.Length;


            Console.WriteLine("The following table shows the result of each possible move from your point of view.");
            Console.WriteLine("For example, 'Win' in the row 'Rock' and column 'Paper' means that Rock beats Paper.");
            Console.WriteLine();

            
            Console.Write("+-------------+");
            for (var i = 0; i < totalMoves; i++)
            {
                Console.Write($"{new string('-', 6)}+");
            }
            Console.WriteLine();

            
            Console.Write("| v PC/User > |");
            for (var i = 0; i < totalMoves; i++)
            {
                Console.Write($" {moves[i],-5} |");
            }
            Console.WriteLine();

            
            Console.Write("+-------------+");
            for (var i = 0; i < totalMoves; i++)
            {
                Console.Write($"{new string('-', 6)}+");
            }
            Console.WriteLine();

           
            for (var i = 0; i < totalMoves; i++)
            {
                Console.Write($"| {moves[i],-11} |");
                for (var j = 0; j < totalMoves; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" Draw  |");
                    }
                    else
                    {
                        var result = RulesChecker.GetResult(i, j, totalMoves);
                        if (result == "You win!")
                            Console.Write(" Win   |");
                        else
                            Console.Write(" Lose  |");
                    }
                }
                Console.WriteLine();

            
                Console.Write("+-------------+");
                for (var j = 0; j < totalMoves; j++)
                {
                    Console.Write($"{new string('-', 6)}+");
                }
                Console.WriteLine();
            }
        }
    }
