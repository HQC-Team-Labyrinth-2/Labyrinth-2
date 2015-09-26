using Labyrinth.configClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Cell
    {
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
                this.row = Validator.CheckIntegerInRange(value, 0, Constants.LABYRINTH_SIZE, "Row");
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
                this.col = Validator.CheckIntegerInRange(value, 0, Constants.LABYRINTH_SIZE, "Col");
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
                this.valueChar = Validator.AllowedSymbols(value);
            }
        }

        public bool IsEmpty()
        {
            if (this.ValueChar == Constants.CELL_EMPTY_VALUE)
            {
                return true;
            }
            return false;
        }
    }
}
