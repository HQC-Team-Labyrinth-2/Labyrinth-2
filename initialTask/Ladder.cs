using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Ladder
    {
        private const int TopResultsCapacity = 5;
        private readonly List<Result> _topResults;

        public Ladder()
        {
            _topResults = new List<Result> {Capacity = TopResultsCapacity};
        }

        /// <summary>
        /// It is used only for testing
        /// This method returns _topResults
        /// </summary>
        public List<Result> _TopResults()
        {
            return _topResults;
        }

        /// <summary>
        /// It is used only for testnig
        /// This method return the capacity
        /// </summary>
        /// <returns></returns>
        public int GetTopResultsCapacity()
        {
            return TopResultsCapacity;
        }


        /// <summary>
        /// It is used only for testing.
        /// This method is similar to PrintLadder, but instead of writing to console, it returns result.
        /// </summary>
        public string ReturnLadder()
        {
            StringBuilder str = new StringBuilder();
            if (_topResults.Count == 0)
            {
                return UserInputAndOutput.SCOREBOARD_EMPTY_MSG;
            }
           
            for (var index = 0; index < _topResults.Count; index++)
            {
                str.AppendLine(string.Format("{0}. {1} --> {2} moves", index + 1,
                    _topResults[index].PlayerName, _topResults[index].MovesCount));
            }

            return str.ToString();
            
        }

        public void PrintLadder()
        {
            if (_topResults.Count == 0)
            {
                Console.WriteLine(UserInputAndOutput.SCOREBOARD_EMPTY_MSG);
            }
            else
            {
                for (var index = 0; index < _topResults.Count; index++)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves", index + 1,
                        _topResults[index].PlayerName, _topResults[index].MovesCount);
                }
            }
        }

        public bool ResultQualifiesInLadder(int result)
        {
            if (_topResults.Count < TopResultsCapacity )
            {
                return true;
            }

            if (result < _topResults.Max().MovesCount)
            {
                return true;
            }

            return false;
        }

        public void AddResultInLadder(int movesCount, string playerName)
        {
            Result result = new Result(movesCount, playerName);
            if (_topResults.Count == _topResults.Capacity)
            {
                _topResults[_topResults.Count - 1] = result;
            }
            else
            {
                _topResults.Add(result);
            }

            SortResults();
        }

        /// <summary>
        /// This method sortResults alphabetically
        /// </summary>
        public void SortResults()
        {
            _topResults.Sort();
        }
    }
}
