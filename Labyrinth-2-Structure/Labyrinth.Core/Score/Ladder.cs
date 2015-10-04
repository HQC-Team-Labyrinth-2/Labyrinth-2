namespace Labyrinth.Core.Score
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Score.Contracts;
    using Labyrinth.Core.Common.Contracts;

    //TODO: add class ContentProvider and provide the result for print!
    public class Ladder : ILadder, IContentProvider
    {
        private List<Result> topResults;
        private IRenderer outputRenderer;
        private static object syncRoot = new Object();

        private static Ladder instance;
        private int capacity;

        private Ladder()
        {
            this.topResults = new List<Result>();
            this.Capacity = Constants.StandardGameTopResultCapacity;
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

        //public void PrintLadder()
        //{
        //    if (topResults.Count == 0)
        //    {
        //        this.outputRenderer.PrintMessage(GlobalErrorMessages.ScoreBoardEmptyMessage);
        //    }
        //    else
        //    {
        //        for (int index = 0; index < topResults.Count; index++)
        //        {
        //            string result = String.Format(
        //                "{0}. {1} --> {2} moves", index + 1,
        //                 topResults[index].PlayerName, topResults[index].MovesCount
        //                 );
        //            this.outputRenderer.PrintMessage(result);
        //        }
        //    }
        //}

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

        public string ProvideContent()
        {
            StringBuilder content = new StringBuilder();

            if (topResults.Count == 0)
            {
                content.Append(GlobalErrorMessages.ScoreBoardEmptyMessage);
                return content.ToString();
                //this.outputRenderer.PrintMessage(GlobalErrorMessages.ScoreBoardEmptyMessage);
            }
            else
            {
                for (int index = 0; index < this.topResults.Count; index++)
                {
                    string result = String.Format(
                        "{0}. {1} --> {2} moves", index + 1,
                        topResults[index].PlayerName, topResults[index].MovesCount
                        );
                    content.AppendLine(result);
                }
                return content.ToString();
                //this.outputRenderer.PrintMessage(result);
            }
        }
    }
}
