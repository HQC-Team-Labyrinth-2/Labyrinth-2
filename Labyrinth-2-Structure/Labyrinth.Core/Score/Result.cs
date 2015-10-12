namespace Labyrinth.Core.Score
{
    using System;
    using Labyrinth.Core.Score.Contracts;

    /// <summary>
    /// Result class
    /// </summary>
    public class Result : IComparable<Result>, IResult
    {
        private int movesCount;
        private string playerName;

        /// <summary>
        /// Constructor for the result.
        /// </summary>
        /// <param name="movesCount">Moves count</param>
        /// <param name="playerName">Player name</param>
        public Result(int movesCount, string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentException("PlayerName must be entered");
            }

            if (movesCount < 0)
            {
                throw new ArgumentException("MovesCount must be positive number or 0");
            }

            this.movesCount = movesCount;
            this.playerName = playerName;
        }

        /// <summary>
        /// Mover count
        /// </summary>
        public int MovesCount
        {
            get
            {
                return this.movesCount;
            }
        }

        /// <summary>
        /// Player name for score ladder.
        /// </summary>
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
        }

        /// <summary>
        /// Method that compares two results.
        /// </summary>
        /// <param name="other">Second result that is compared with current one.</param>
        /// <returns>Comparation reult(-1,0,1)</returns>
        public int CompareTo(Result other)
        {
            int compareResult = this.MovesCount.CompareTo(other.MovesCount);
            return compareResult;
        }
    }
}
