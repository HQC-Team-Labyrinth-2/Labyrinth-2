namespace Labyrinth.ConsoleUI.Input
{
    using System;
    using Labyrinth.Core.Input.Contracts;

    public class Menu : IInfoInputProvider
    {
        public string GetPlayerName()
        {
            return Console.ReadLine();
        }

        public int GetPlayFieldDimensions()
        {
            int result;
            string consoleInput = Console.ReadLine();
            if (int.TryParse(consoleInput, out result))
            {
                return result;
            }

            throw new ArgumentException("Dimension of the play field must be an integer number!");
        }
    }
}
