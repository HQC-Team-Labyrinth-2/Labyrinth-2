namespace Labyrinth.ConsoleUI.Output
{
    using System;
    using Labyrinth.Core.Helpers;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class PlayFieldPanel : IPlayFieldRenderer
    {
        public void ShowPlayField(IPlayField playField)
        {
            for (int row = 0; row < playField.NumberOfRows; row++)
            {
                for (int col = 0; col < playField.NumberOfCols; col++)
                {
                    ICell cell = playField.GetCell(new Position(row, col));
                    Console.Write(cell.ValueChar + " ");
                }

                Console.WriteLine();
            }
        }

        public void ClearPlayField()
        {
            Console.Clear();
        }
    }
}
