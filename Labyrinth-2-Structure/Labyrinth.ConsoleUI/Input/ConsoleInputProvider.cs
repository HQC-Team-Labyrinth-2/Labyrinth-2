namespace Labyrinth.ConsoleUI.Input
{
    using Labyrinth.Core.Input.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private readonly ICommandInputProvider commandInput;

        private readonly IMenuInputProvider menuInput;

        public ConsoleInputProvider(ICommandInputProvider cmdInput, IMenuInputProvider menuInput)
        {
            this.commandInput = cmdInput;
            this.menuInput = menuInput;
        }

        public string GetCommand()
        {
            return this.commandInput.GetCommand();
        }

        public string GetPlayerName()
        {
            return this.menuInput.GetPlayerName();
        }

        public int GetPlayFieldDimensions()
        {
            return this.menuInput.GetPlayFieldDimensions();
        }
    }
}
