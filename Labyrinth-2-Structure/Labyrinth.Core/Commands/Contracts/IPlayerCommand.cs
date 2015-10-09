namespace Labyrinth.Core.Commands.Contracts
{
    using Labyrinth.Core.Common;

    public interface IPlayerCommand
    {
        Direction Direction { get; set; }
    }
}
