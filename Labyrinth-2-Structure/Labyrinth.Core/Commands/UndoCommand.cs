namespace Labyrinth.Core.Commands
{
    using System.Linq;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class UndoCommand:ICommand
    {
        public int Execute(ICommandContext context)
        {
            if (context.Memory != null && context.Memory.Memento != null)
            {
                if (context.Memory.Memento.Count != 0)
                { 
                ((IMemorizable)context.PlayField).RestoreMemento(context.Memory.Memento.Last());
                context.Memory.Memento.Remove(context.Memory.Memento.Last());
                }

                return -1;
            }

            return 0;
        }
    }
}
