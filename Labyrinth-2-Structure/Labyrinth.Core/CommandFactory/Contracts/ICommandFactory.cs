using Labyrinth.Core.Commands.Contracts;

namespace Labyrinth.Core.CommandFactory.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string command);
    }
}
