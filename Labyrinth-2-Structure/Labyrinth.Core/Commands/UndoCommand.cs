namespace Labyrinth.Core.Commands
{
    using System.Linq;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Helpers.Contracts;

    /// <summary>
    /// Undo command class.
    /// </summary>
    public class UndoCommand : ICommand
    {
        /// <summary>
        /// Method that execute undo command(returns the player on the previous position on the playfield).
        /// </summary>
        /// <param name="context">Contains all parameters that command need for execution.</param>
        public void Execute(ICommandContext context)
        {
            if (context.Memory != null && context.Memory.Memento != null)
            {
                if (context.Memory.Memento.Count != 0)
                {
                    context.PlayField.RestoreMemento(context.Memory.Memento.Last());
                    context.Memory.Memento.Remove(context.Memory.Memento.Last());
                    context.Player.CurentCell = context.PlayField.GetCell(context.PlayField.PlayerPosition);
                    context.Player.MovesCount--;
                }
            }
        }

        /// <summary>
        /// Method that returns the name of the command.
        /// </summary>
        /// <returns>Command name.</returns>
        public string GetName()
        {
            return "Undo";
        }
    }
}
