using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Result: IComparable<Result>
    {
        private int movesCount; 
        private string playerName;

        public Result(int movesCount, string playerName)
        {
            this.MovesCount = movesCount;
            this.PlayerName = playerName;
        }

        public int MovesCount 
        {
            get
            {
                return this.movesCount;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Moves count must be greater than 0!");
                }
                else
                {
                    this.movesCount = value;
                }
            }
        }
        public string PlayerName 
        {
            get
            {
                return this.playerName;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player name can't be null or empty string!");
                }
                else
                {
                    this.playerName = value;
                }
            }
        }

        public int CompareTo(Result other)
        {
            int compareResult = this.MovesCount.CompareTo(other.MovesCount);
            return compareResult;
        }
    }
}
