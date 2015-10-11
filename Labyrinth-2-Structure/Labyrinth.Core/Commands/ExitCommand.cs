namespace Labyrinth.Core.Commands
{
    using System;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;

    /// <summary>
    /// Exit command class.
    /// </summary>
    public class ExitCommand : ICommand
    {
        /// <summary>
        /// Method that execute exit command(exit from the game).
        /// </summary>
        /// <param name="commandContext">Contains all parameters that need for command execute.</param>
        public void Execute(ICommandContext commandContext)
        {
            commandContext.Output.ShowInfoMessage(GlobalMessages.GoodbyeMessage);
            Environment.Exit(0);
        }

        /// <summary>
        /// Method that returns the name of the command.
        /// </summary>
        /// <returns>Name of the command.</returns>
        public string GetName()
        {
            return "Exit";
        }
    }
}
