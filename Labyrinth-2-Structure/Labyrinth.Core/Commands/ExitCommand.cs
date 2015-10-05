namespace Labyrinth.Core.Commands
{
    using System;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    public class ExitCommand:ICommand
    {
        public int Execute(ICommandContext commandContext)
        {
            commandContext.Output.PrintMessage(GlobalMessages.GoodbyeMessage);
            Environment.Exit(0);
            return 0;
        }

        public string GetName()
        {
            return "Exit";
        }
    }
}
