namespace Labyrinth.Core.GameEngine
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.GameEngine.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public abstract class GameEngine : IGameEngine
    {
        protected readonly IPlayField PlayField;

        protected GameEngine(IPlayField playField)
        {
            this.PlayField = playField;
        }

        public abstract void Initialize(IRandomGenerator randomGenerator);

        public abstract void Start();
    }
}
