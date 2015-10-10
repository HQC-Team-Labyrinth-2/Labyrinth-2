namespace Labyrinth.Core.Commands.Contracts
{
    using Labyrinth.Core.Helpers.Contracts;

    public interface ICommand
    {
        void Execute(ICommandContext commandContext);

        string GetName();
    }
}
