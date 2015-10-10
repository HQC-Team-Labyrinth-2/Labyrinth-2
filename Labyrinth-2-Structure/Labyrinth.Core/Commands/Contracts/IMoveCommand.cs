namespace Labyrinth.Core.Commands.Contracts
{
    using Labyrinth.Core.Common;

    public interface IMoveCommand
    {
        Direction Direction { get; set; }
    }
}
