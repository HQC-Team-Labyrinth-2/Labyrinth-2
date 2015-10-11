namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Common.Contracts;

    public interface IPlayFieldGenerator
    {
        ICell[,] GeneratePlayField(IRandomNumberGenerator rand);
    }
}
