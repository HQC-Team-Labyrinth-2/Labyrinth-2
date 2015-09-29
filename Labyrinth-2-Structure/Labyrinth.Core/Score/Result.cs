﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.Score
{
    //TODO:Implement a resultComparator class that implament function for compare two results
    public class Result : IComparable<Result>
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
