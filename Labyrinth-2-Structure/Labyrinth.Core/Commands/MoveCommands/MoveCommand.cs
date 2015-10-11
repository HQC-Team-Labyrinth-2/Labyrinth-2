namespace Labyrinth.Core.Commands.MoveCommands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Player.Contracts;

    /// <summary>
    /// Abstract class that is inherited by all move commands
    /// </summary>
    public abstract class MoveCommand : ICommand, IMoveCommand
    {
        /// <summary>
        /// Constructor for the MoveCommand class
        /// </summary>
        /// <param name="direction">The direction in which the player want to move</param>
        public MoveCommand(Direction direction)
        {
            this.Direction = direction;
        }

        /// <summary>
        /// Direction property
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Method that execute the movement in the given direction for this command.
        /// </summary>
        /// <param name="commandContext">Contains all parameters needed for the current command to be executed.</param>
        public void Execute(ICommandContext commandContext)
        {
            commandContext.Memory.Memento.Add(commandContext.PlayField.SaveMemento());

            IPosition newPosition = this.FindNewCellPosition(this.Direction, commandContext.Player);

            commandContext.PlayField.RemovePlayer(commandContext.Player);
            commandContext.PlayField.AddPlayer(commandContext.Player, newPosition);
            commandContext.Player.MovesCount++;
        }

        /// <summary>
        /// Abstract method that returns the name  of the  command
        /// </summary>
        /// <returns>Name of the command</returns>
        public abstract string GetName();

        /// <summary>
        /// Method that find the new position based od the  player position and the move command direction.
        /// </summary>
        /// <param name="direction">Move command direction.</param>
        /// <param name="player">Player that needs to be moved.</param>
        /// <returns>New position where the player should be moved on.</returns>
        private IPosition FindNewCellPosition(Direction direction, IPlayer player)
        {
            int newRow = player.CurentCell.Position.Row;
            int newCol = player.CurentCell.Position.Column;

            if (direction == Direction.Up)
            {
                newRow = newRow - 1;
            }
            else
                if (direction == Direction.Down)
                {
                    newRow = newRow + 1;
                }
                else
                    if (direction == Direction.Left)
                    {
                        newCol = newCol - 1;
                    }
                    else
                        if (direction == Direction.Right)
                        {
                            newCol = newCol + 1;
                        }

            return new Position(newRow, newCol);
        }
    }
}