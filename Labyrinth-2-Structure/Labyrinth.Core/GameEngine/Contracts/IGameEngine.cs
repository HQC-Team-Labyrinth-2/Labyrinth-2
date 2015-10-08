namespace Labyrinth.Core.GameEngine.Contracts
{
    using Labyrinth.Common.Contracts;

    public interface IGameEngine
    {
        void Initialize(IRandomGenerator random);

        void Start();
    }
}
