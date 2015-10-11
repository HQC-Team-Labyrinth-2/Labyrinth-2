namespace Labyrinth.Core.Commands.MoveCommands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    /// <summary>
    /// Move up command.
    /// </summary>
    public class MoveUp : MoveCommand, ICommand
    {
        /// <summary>
        /// Constructor for MoveUp command.
        /// </summary>
        public MoveUp()
            : base(Direction.Up)
        {
        }

        /// <summary>
        /// Method that returns the  name of the command.
        /// </summary>
        /// <returns>Name of the command.</returns>
        public override string GetName()
        {
            return "Move Up";
        }
    }
}
