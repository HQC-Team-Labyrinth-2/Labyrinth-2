namespace Labyrinth.Core.CommandFactory.Contracts
{
    using Labyrinth.Core.Commands.Contracts;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string command);
    }
}
