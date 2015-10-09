namespace Labyrinth.Core.Commands.Contracts
{
    public interface ICommand
    {
        void Execute(ICommandContext commandContext);
        string GetName();
    }
}
