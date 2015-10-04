using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Common.Contracts;
namespace Labyrinth.Core.GameEngine
{
    using Labyrinth.Core.GameEngine.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public abstract class GameEngine:IGameEngine
    {
        protected readonly IPlayField playField;

        protected  GameEngine(IPlayField playField)
        {
            this.playField = playField;
        }

        public abstract void Initialize(IRandomGenerator randomGenerator);

        public abstract void Start();

    }
}
