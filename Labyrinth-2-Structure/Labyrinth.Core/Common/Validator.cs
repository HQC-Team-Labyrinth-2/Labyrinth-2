namespace Labyrinth.Core.Common
{
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public static class Validator
    {
        public static bool CheckWinningConditions(IPlayField playField, IPlayer player)
        {
            bool isGameOver = false;
            int currentRow = player.CurentCell.Position.Row;
            int currentCol = player.CurentCell.Position.Column;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Constants.StandardGameLabyrinthRows - 1 ||
                currentCol == Constants.StandardGameLabyrinthCols - 1)
            {
                isGameOver = true;
            }

           return isGameOver;
        }
    }
}
