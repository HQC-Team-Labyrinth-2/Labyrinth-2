using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.configClasses
{
    public static class Validator
    {
        public static int CheckIntegerInRange(int value, int min, int max, string field)
        {
            if (value >= max)
            {
                throw new ArgumentOutOfRangeException("The value of " + field + " cannot be more or equal to " + max);
            }
            if (value < min)
            {
                throw new ArgumentOutOfRangeException("The value of " + field + " cannot be less than " + min);
            }
            return value;
        }

        public static char AllowedSymbols(char symbol)
        {
            if (
                symbol == Constants.CELL_WALL_VALUE ||
                symbol == Constants.CELL_EMPTY_VALUE ||
                symbol == Constants.CELL_PLAYER_VALUE
                )
            {
                return symbol;
            }
            else
            {
                throw new ArgumentException("invalid char  was written");
            }
        }
    }
}
