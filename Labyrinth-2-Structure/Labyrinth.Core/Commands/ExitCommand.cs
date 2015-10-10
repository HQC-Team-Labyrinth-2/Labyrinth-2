namespace Labyrinth.Core.Commands
{
    using System;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;

    public class ExitCommand : ICommand
    {
        public void Execute(ICommandContext commandContext)
        {
            commandContext.Output.ShowInfoMessage(GlobalMessages.GoodbyeMessage);
            Environment.Exit(0);
        }

        public string GetName()
        {
            return "Exit";
        }
    }
}
