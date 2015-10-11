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

    public class ScoreLadder : IScoreLadder, IScoreLadderContentProvider
    {
        private static object syncRoot = new object();
        private static ScoreLadder instance;
        private int capacity;
        private List<Result> topResults;

        private ScoreLadder()
        {
            this.topResults = new List<Result>();
            this.Capacity = Constants.StandardGameTopResultCapacity;
        }

        public static ScoreLadder Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ScoreLadder();
                        }
                    }
                }

                return instance;
            }
        }

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

        public void AddResultInLadder( int movesCount, string playerName)
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

        public int CurrentCount()
        {
            return this.topResults.Count;
        }

        public void RestartLadder()
        {
            instance = null;
        }
    }
}
