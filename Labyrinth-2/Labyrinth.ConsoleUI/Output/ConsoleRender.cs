using Labyrinth.Core.Common;
using Labyrinth.Core.Output.Contracts;
using Labyrinth.Core.PlayField.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.ConsoleUI.Output
{
    public class ConsoleRender : IRenderer
    {

        public void PrintGetInputMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void PrintPlayField(IPlayField playField, int labyrinthRows, int labyrinthColumns)
        {
            for (int row = 0; row < labyrinthRows; row++)
            {
                for (int col = 0; col < labyrinthColumns; col++)
                {
                    ICell cell = playField.GetCell(new Position(row, col));
                    Console.Write(cell.ValueChar + " ");
                }
                Console.WriteLine();
            }
        }

        public void PrintWelcomeMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void PrintPlayField(IPlayField playField)
        {
            for (int row = 0; row < playField.NumberOfRows; row++)
            {
                for (int col = 0; col < playField.NumberOfCols; col++)
                {
                    ICell cell = playField.GetCell(new Position(row,col));
                    Console.Write(cell.ValueChar + " ");
                }
                Console.WriteLine();
            }
        }

        public void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
