namespace Rock_Paper_Scissors;

    public static class RulesChecker
    {
        public static string GetResult(int userMoveIndex, int computerMoveIndex, int totalMoves)
        {
            if (userMoveIndex == computerMoveIndex)
            {
                return "It's a draw!";
            }
            
            var half = totalMoves / 2;
            
            var diff = (computerMoveIndex - userMoveIndex + totalMoves) % totalMoves;

            if (diff <= half) 
            {
                return "Computer wins!";
            }
            else 
            {
                return "You win!";
            }
        }
    }