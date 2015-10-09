using Labyrinth.Core.Commands.Contracts;
using Labyrinth.Core.Common;
using Labyrinth.Core.Player.Contracts;

namespace Labyrinth.Core.Commands
{
    public abstract class MoveCommand : ICommand, IPlayerCommand
    {
        public MoveCommand(Direction direction)
        {
            this.Direction = direction;
        }

        public void Execute(ICommandContext commandContext)
        {
            commandContext.Memory.Memento.Add(commandContext.PlayField.SaveMemento());

            IPosition newPosition = this.FindNewCellPosition(this.Direction, commandContext.Player);
           // Validator.CheckIfPlayerMovedOnEmptyPosition(newPosition, commandContext.PlayField);

            commandContext.PlayField.RemovePlayer(commandContext.Player);
            commandContext.PlayField.AddPlayer(commandContext.Player, newPosition);
            commandContext.Player.MovesCount++;
        }

        public abstract string GetName();

        //TODO: Change this enum with constants
        public Direction Direction { get; set; }

        private IPosition FindNewCellPosition(Direction direction, IPlayer player)
        {
            int newRow = player.CurentCell.Position.Row;
            int newCol = player.CurentCell.Position.Column;

            if (direction == Direction.Up)
            {
                newRow = newRow - 1;
            }
            else if (direction == Direction.Down)
            {
                newRow = newRow + 1;
            }
            else if (direction == Direction.Left)
            {
                newCol = newCol - 1;
            }
            else if (direction == Direction.Right)
            {
                newCol = newCol + 1;
            }

            return new Position(newRow, newCol);
        }

    }

}