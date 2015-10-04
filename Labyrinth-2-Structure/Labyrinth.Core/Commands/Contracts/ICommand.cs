namespace Labyrinth.Core.Commands.Contracts
{
    public interface ICommand
    {
        int Execute(ICommandContext commandContext);
    }
}
