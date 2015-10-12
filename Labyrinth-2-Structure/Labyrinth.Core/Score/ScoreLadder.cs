namespace Labyrinth.Core.Score
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Score.Contracts;

    /// <summary>
    /// Singleton class that stores top results.
    /// </summary>
    public class ScoreLadder : IScoreLadder, IScoreLadderContentProvider
    {
        private static ScoreLadder instance;
        private int capacity;
        private List<Result> topResults;

        /// <summary>
        /// Constructor
        /// </summary>
        private ScoreLadder()
        {
            this.topResults = new List<Result>();
            this.Capacity = Constants.StandardGameTopResultCapacity;
        }

        /// <summary>
        /// Property that set and return 
        /// </summary>
        public static ScoreLadder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreLadder();
                }

                return instance;
            }
        }

        /// <summary>
        /// Capacity of the score ladder.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Capacity can't be negativ!");
                }

                this.capacity = value;
            }
        }

        /// <summary>
        /// Check the result if qualifies to be added in the ladder.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool ResultQualifiesInLadder(int result)
        {
            if (this.topResults.Count < Constants.StandardGameTopResultCapacity)
            {
                return true;
            }

            if (result < this.topResults.Max().MovesCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds the  result in the ladder.
        /// </summary>
        /// <param name="movesCount">Moves count</param>
        /// <param name="playerName">Player name</param>
        public void AddResultInLadder(int movesCount, string playerName)
        {
            Result result = new Result(movesCount, playerName);
            if (this.topResults.Count == this.Capacity)
            {
                this.topResults[this.topResults.Count - 1] = result;
            }
            else
            {
                this.topResults.Add(result);
            }

            this.topResults.Sort();
        }

        /// <summary>
        /// Provide the ladder for showing in the UI.
        /// </summary>
        /// <returns>Top results</returns>
        public string ProvideContent()
        {
            StringBuilder content = new StringBuilder();

            if (this.topResults.Count == 0)
            {
                content.Append(GlobalErrorMessages.ScoreBoardEmptyMessage);
                return content.ToString();
            }
            else
            {
                for (int index = 0; index < this.topResults.Count; index++)
                {
                    string result = string.Format("{0}. {1} --> {2} moves", index + 1, this.topResults[index].PlayerName, this.topResults[index].MovesCount);
                    content.AppendLine(result);
                }

                return content.ToString();
            }
        }

        /// <summary>
        /// Returns the current count of results in the lader.
        /// </summary>
        /// <returns></returns>
        public int CurrentCount()
        {
            return this.topResults.Count;
        }

        /// <summary>
        /// Initialize Singleton instanfe to null.
        /// </summary>
        public void RestartLadder()
        {
            instance = null;
        }
    }
}
