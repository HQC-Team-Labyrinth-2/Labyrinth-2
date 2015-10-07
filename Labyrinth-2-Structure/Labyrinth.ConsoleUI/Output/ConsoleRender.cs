namespace Labyrinth.ConsoleUI.Output
{
    using System;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class ConsoleRender : IRenderer
    {
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

        public void Show(IContentProvider provider)
        {
           Console.WriteLine(provider.ProvideContent());
        }
    }
}
