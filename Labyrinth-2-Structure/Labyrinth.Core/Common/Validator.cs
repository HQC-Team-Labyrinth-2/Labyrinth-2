using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Core.Player.Contracts;
using Labyrinth.Core.PlayField.Contracts;

namespace Labyrinth.Core.Common
{
    public static class Validator
    {
        public static void CheckIfNewPositionIsValid(IPosition position,IPlayField playField)
        {
            if (position.Row < 0 || position.Column < 0 ||
                position.Row >= Constants.StandardGameLabyrinthRows || position.Column >= Constants.StandardGameLabyrinthCols)
            {
                throw new ArgumentOutOfRangeException("The position is outside of the playfield, Game is over");
            }

            if (!playField.GetCell(position).IsEmpty())
            {
                throw new ArgumentException("The next position is not emtpy, Game is over");
            }
            
        }

        public static void CheckIfPlayerCanMoveOnCell(ICell cell)
        {
            if (!cell.IsEmpty())
            {
                throw new ArgumentException("Player can't move in given direction, the  game  is over!");
            }

        }

        public static void CheckWinningConditions(IPlayField playField, IPlayer player)
        {
            bool isGameOver = false;
            int currentRow = player.CurentCell.Position.Row;
            int currentCol = player.CurentCell.Position.Column;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Constants.StandardGameLabyrinthRows - 1 ||
                currentCol == Constants.StandardGameLabyrinthCols - 1)
            {
               // return true;
            }

           // return isGameOver;
        }
    }
}
