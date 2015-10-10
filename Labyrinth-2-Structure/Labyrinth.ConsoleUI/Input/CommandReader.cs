namespace Labyrinth.ConsoleUI.Input
{
    using System;
    using Labyrinth.Core.Input.Contracts;

    public class CommandReader : ICommandInputProvider
    {
        public string GetCommand()
        {
            ConsoleKeyInfo k = Console.ReadKey(false);
           
            switch (k.Key)
            {
                case ConsoleKey.UpArrow:
                    return "u";
                case ConsoleKey.DownArrow:
                    return "d";
                case ConsoleKey.LeftArrow:
                    return "l";
                case ConsoleKey.RightArrow:
                    return "r";
                case ConsoleKey.R:
                    return "restart";
                case ConsoleKey.U:
                    return "undo";
                case ConsoleKey.E:
                    return "exit";
                case ConsoleKey.T:
                    return "top";
                default:
                    return k.KeyChar.ToString();
            }
        }
    }
}
