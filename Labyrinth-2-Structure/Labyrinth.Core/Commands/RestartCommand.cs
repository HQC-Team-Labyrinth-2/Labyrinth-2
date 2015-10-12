namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers;
    using Labyrinth.Core.Helpers.Contracts;

    /// <summary>
    /// Restart command class.
    /// </summary>
    public class RestartCommand : ICommand
    {
        /// <summary>
        /// Methot that execute restart command(restart the game).
        /// </summary>
        /// <param name="context">Contains all parameters that command need for execute.</param>
        public void Execute(ICommandContext context)
        {
            context.PlayField.InitializePlayFieldCells(RandomNumberGenerator.Instance);
            
            context.Memory.Memento.Clear();

            context.Player.MovesCount = 0;
            context.Player.CurentCell = context.PlayField.GetCell(context.Player.StartPosition);
            context.PlayField.PlayerPosition = context.Player.StartPosition;
        }

        /// <summary>
        /// Method that returns the name of the command.
        /// </summary>
        /// <returns>Name of the command.</returns>
        public string GetName()
        {
            return "Restart";
        }
    }
}
