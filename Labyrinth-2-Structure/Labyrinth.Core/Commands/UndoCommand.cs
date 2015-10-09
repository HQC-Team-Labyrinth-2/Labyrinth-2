namespace Labyrinth.Core.Commands
{
    using System.Linq;
    using Labyrinth.Core.Commands.Contracts;

    public class UndoCommand : ICommand
    {
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

        public string GetName()
        {
            return "Undo";
        }
    }
}
