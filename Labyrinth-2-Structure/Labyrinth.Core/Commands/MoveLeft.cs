namespace Labyrinth.Core.Commands
{
    using System;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Common;

    public class MoveLeft : ICommand
    {
        public int Execute(ICommandContext context)
        {
            context.Memory.Memento.Add((((IMemorizable)context.PlayField).SaveMemento()));

            context.PlayField.TryMove(context.PlayField.GetCell(context.PlayField.PlayerPosition), Direction.Left);

            return 1;
        }
    }
}
