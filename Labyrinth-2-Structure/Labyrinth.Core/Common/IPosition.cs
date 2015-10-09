namespace Labyrinth.Core.Common
{
    using Labyrinth.Core.Commands.Contracts;

    public interface IPosition:ICloneablePosition
    {
        int Row { get; set; }

        int Column { get; set; }
    }
}
