namespace Labyrinth.Core.Input.Contracts
{
    using Labyrinth.Core.Output.Contracts;

    public interface IInputProvider
    {
        string GetCommand();

        string GetPlayerName();

        string GetPlayFieldDimensions();
    }
}
