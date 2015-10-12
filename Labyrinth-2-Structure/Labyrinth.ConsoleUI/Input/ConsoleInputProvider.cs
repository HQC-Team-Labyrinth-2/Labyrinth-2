namespace Labyrinth.ConsoleUI.Input
{
    using Labyrinth.Core.Input.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private readonly ICommandInputProvider commandInput;

        private readonly IInfoInputProvider menuInput;

        public ConsoleInputProvider(ICommandInputProvider cmdInput, IInfoInputProvider menuInput)
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
