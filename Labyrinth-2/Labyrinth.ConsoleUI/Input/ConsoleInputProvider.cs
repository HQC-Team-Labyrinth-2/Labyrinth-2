namespace Labyrinth.ConsoleUI.Input
{
    using System;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public string GetInput(IRenderer console)
        {
            console.PrintMessage(GlobalMessages.GetInputMessage);
            string inputLine = Console.ReadLine();
            return inputLine;
        }

        public string GetPlayerName()
        {
            return Console.ReadLine();
        }
    }
}
