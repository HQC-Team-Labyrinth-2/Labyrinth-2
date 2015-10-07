namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Common;

    public class MoveRight : ICommand
    {
        public int Execute(ICommandContext context)
        {
            context.Memory.Memento.Add(context.PlayField.SaveMemento());

            context.PlayField.TryMove(context.PlayField.GetCell(context.PlayField.PlayerPosition), Direction.Right);

            return 1;
        }

        public string GetName()
        {
            return "Move Right";

        }
    }
}
