using Labyrinth.Core.Score.Contracts;

namespace Labyrinth.Core.Score
{
    using System;

    //TODO:Implement a resultComparator class that implament function for compare two results
    public class Result : IComparable<Result>, IResult
    {
        private int movesCount;
        private string playerName;

        public Result(int movesCount, string playerName)
        {
            this.movesCount = movesCount;
            this.playerName = playerName;
        }

        public int MovesCount
        {
            get
            {
                return this.movesCount;
            }
        }
        
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
        }

        public int CompareTo(Result other)
        {
            int compareResult = this.MovesCount.CompareTo(other.MovesCount);
            return compareResult;
        }
    }
}
