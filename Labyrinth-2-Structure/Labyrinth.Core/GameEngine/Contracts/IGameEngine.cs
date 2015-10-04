using Labyrinth.Common.Contracts;

namespace Labyrinth.Core.GameEngine.Contracts
{
   public interface IGameEngine
    {
        void Initialize(IRandomGenerator random);

        void Start();
    }
}
