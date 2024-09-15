using System.Security.Cryptography;

namespace Rock_Paper_Scissors;
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Error: You must provide an odd number of at least 3 non-repeating moves.");
                Console.WriteLine("Example: > dotnet run rock paper scissors lizard Spock");
                return;
            }

            var moves = args;
            var computerMoveIndex = GetRandomMove(moves.Length);
            var computerMove = moves[computerMoveIndex];
            
            var key = HmacGenerator.GenerateRandomKey();
            var hmac = HmacGenerator.GenerateHmac(key, computerMove);

            Console.WriteLine($"HMAC: {BitConverter.ToString(hmac).Replace("-", "")}");
            Console.WriteLine("Available moves:");
            for (var i = 0; i < moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {moves[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");

            while (true)
            {
                Console.Write("Enter your move: ");
                var userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }

                if (userInput == "?")
                {
                    HelpGenerator.DisplayHelpTable(moves);
                }
                else if (int.TryParse(userInput, out var userMoveIndex) && userMoveIndex > 0 && userMoveIndex <= moves.Length)
                {
                    userMoveIndex--; 
                    var userMove = moves[userMoveIndex];

                    Console.WriteLine($"Your move: {userMove}");
                    Console.WriteLine($"Computer move: {computerMove}");

                    var result = RulesChecker.GetResult(userMoveIndex, computerMoveIndex, moves.Length);
                    Console.WriteLine(result);

                    Console.WriteLine($"HMAC key: {BitConverter.ToString(key).Replace("-", "")}");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
        
        static int GetRandomMove(int numberOfMoves)
        {
            var randomNumber = new byte[4]; 
            RandomNumberGenerator.Fill(randomNumber); 
            return Math.Abs(BitConverter.ToInt32(randomNumber, 0)) % numberOfMoves; 
        }
    }

