namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Commands.Contracts;

    public class MoveUp: ICommand
    {
        public int Execute(ICommandContext context)
        {
            context.Memory.Memento.Add((((IMemorizable)context.PlayField).SaveMemento()));

            context.PlayField.TryMove(context.PlayField.GetCell(context.PlayField.PlayerPosition), Direction.Up);

            return 1;
        }
    }
}
