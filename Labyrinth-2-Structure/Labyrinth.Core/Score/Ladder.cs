namespace Labyrinth.Core.Score
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Score.Contracts;

    //TODO: add class ContentProvider and provide the result for print!
    public class Ladder : ILadder
    {
        private List<Result> topResults;
        private IRenderer outputRenderer;
        private static object syncRoot = new Object();

        private static Ladder instance;
        private int capacity;

        private Ladder()
        {
            topResults = new List<Result>();
        }

        public static Ladder Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Ladder();
                    }
                }

                return instance;
            }
        }

        public IRenderer OutputRenderer
        {
            get
            {
                return this.outputRenderer;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Output renderer can't be null!");
                }
                this.outputRenderer = value;
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

        public void PrintLadder()
        {
            if (topResults.Count == 0)
            {
                this.outputRenderer.PrintMessage(GlobalErrorMessages.ScoreBoardEmptyMessage);
            }
            else
            {
                for (int index = 0; index < topResults.Count; index++)
                {
                    string result = String.Format(
                        "{0}. {1} --> {2} moves", index + 1,
                         topResults[index].PlayerName, topResults[index].MovesCount
                         );
                    this.outputRenderer.PrintMessage(result);
                }
            }
        }

        public bool ResultQualifiesInLadder(int result)
        {
            if (topResults.Count < Constants.StandardGameTopResultCapacity)
            {
                return true;
            }
            if (result < topResults.Max().MovesCount)
            {
                return true;
            }
            return false;
        }

        public void AddResultInLadder(int movesCount, string playerName)
        {
            Result result = new Result(movesCount, playerName);
            if (topResults.Count == this.Capacity)
            {
                topResults[topResults.Count - 1] = result;
            }
            else
            {
                topResults.Add(result);
            }
            topResults.Sort();
        }
    }
}
