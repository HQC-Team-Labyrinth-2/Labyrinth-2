using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
   public class Cell
    {

        public const int maxSize=Labyrinth.LABYRINTH_SIZE;
        public const char CELL_EMPTY_VALUE = '-';
        public const char CELL_WALL_VALUE = 'X';
    
      
        private int row;
        private int col;
        private char valueChar;

        public Cell()
        {

        }

        public Cell(int row, int col, char value)
        {
            this.Row = row;
            this.Col = col;
            this.ValueChar = value;
        }



        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if(value>=maxSize || value<=0)
                {
                    throw new ArgumentOutOfRangeException("invalid row was written");
                }
                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                if (value >= maxSize || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("invalid row was written");
                }
                this.col = value;
            }
        }

        public char ValueChar
        {
            get
            {
                return this.valueChar;
            }
            set
            {
                if (value != 'X' && value != '-' && value != '*')
                {
                    throw new ArgumentException("invalid char  was written");
                }
                this.valueChar = value;
            }
        }

        public bool IsEmpty()
        {
            if(this.ValueChar == CELL_EMPTY_VALUE)
            {
                return true;
            }
            return false;
        }
    }
}
