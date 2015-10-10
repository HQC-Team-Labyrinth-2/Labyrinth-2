namespace Labyrinth.ConsoleUI.Input
{
    using System;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private readonly ICommandInputProvider CommandInput;

        private readonly IMenuInputProvider MenuInput;

        public ConsoleInputProvider(ICommandInputProvider cmdInput, IMenuInputProvider menuInput)
        {
            this.CommandInput = cmdInput;
            this.MenuInput = menuInput;
        }

        public string GetCommand()
        {
            return this.CommandInput.GetCommand();
        }

        public string GetPlayerName()
        {
            return this.MenuInput.GetPlayerName();
        }

        public string GetPlayFieldDimensions()
        {
            return this.GetPlayFieldDimensions();
        }
    }
}
