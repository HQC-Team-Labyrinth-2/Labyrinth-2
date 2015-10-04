namespace Labyrinth.Core.Input.Contracts
{
    using Labyrinth.Core.Output.Contracts;

    public interface IInputProvider
    {
        string GetInput(IRenderer outputRenderer);

        string GetPlayerName();
    }
}
