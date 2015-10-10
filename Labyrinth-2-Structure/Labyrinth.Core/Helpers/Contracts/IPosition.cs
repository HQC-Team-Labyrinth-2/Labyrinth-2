namespace Labyrinth.Core.Helpers.Contracts
{
    public interface IPosition : ICloneablePosition
    {
        int Row { get; set; }

        int Column { get; set; }
    }
}
