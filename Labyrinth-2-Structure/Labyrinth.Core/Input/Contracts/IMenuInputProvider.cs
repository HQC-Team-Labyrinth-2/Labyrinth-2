namespace Labyrinth.Core.Input.Contracts
{
    public interface IMenuInputProvider
    {
        string GetPlayerName();

        int GetPlayFieldDimensions();
    }
}
