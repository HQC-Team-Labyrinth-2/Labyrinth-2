namespace Labyrinth.Core.Commands.Contracts
{
    using Labyrinth.Core.Common;

    public interface ICloneablePosition
    {
        IPosition Clone();
    }
}
