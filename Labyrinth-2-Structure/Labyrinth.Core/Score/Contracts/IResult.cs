namespace Labyrinth.Core.Score.Contracts
{
    public interface IResult
    {
        int MovesCount { get; }

        string PlayerName { get; }
    }
}