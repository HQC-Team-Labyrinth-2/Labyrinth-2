namespace Labyrinth.Core.Commands.MoveCommands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    /// <summary>
    /// Move down command
    /// </summary>
    public class MoveDown : MoveCommand, ICommand
    {
        /// <summary>
        /// Constructor for the move down command.
        /// </summary>
        public MoveDown()
            : base(Direction.Down)
        {
        }

        /// <summary>
        /// Method that returns the name  of the  command.
        /// </summary>
        /// <returns>Name of the command.</returns>
        public override string GetName()
        {
            return "Move Down";
        }
    }
}
