namespace Rock_Paper_Scissors;

    public static class HelpGenerator
    {
        public static void DisplayHelpTable(string[] moves)
        {
            var totalMoves = moves.Length;

            // Print explanation before the table
            Console.WriteLine("The following table shows the result of each possible move from your point of view.");
            Console.WriteLine("For example, 'Win' in the row 'Rock' and column 'Paper' means that Rock beats Paper.");
            Console.WriteLine();

            // Print the top border of the table
            Console.Write("+-------------+");
            for (var i = 0; i < totalMoves; i++)
            {
                Console.Write($"{new string('-', 6)}+");
            }
            Console.WriteLine();

            // Print the column headers
            Console.Write("| v PC/User > |");
            for (var i = 0; i < totalMoves; i++)
            {
                Console.Write($" {moves[i],-5} |");
            }
            Console.WriteLine();

            // Print the separator below the headers
            Console.Write("+-------------+");
            for (var i = 0; i < totalMoves; i++)
            {
                Console.Write($"{new string('-', 6)}+");
            }
            Console.WriteLine();

            // Print each row with move results
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

                // Print separator between rows
                Console.Write("+-------------+");
                for (var j = 0; j < totalMoves; j++)
                {
                    Console.Write($"{new string('-', 6)}+");
                }
                Console.WriteLine();
            }
        }
    }
