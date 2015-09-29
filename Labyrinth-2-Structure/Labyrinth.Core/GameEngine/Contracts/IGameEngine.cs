using Labyrinth.Core.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.GameEngine.Contracts
{
   public interface IGameEngine
    {
        IEnumerable<ICharacter> Players { get; }

        void Initialize();

        void Start();
    }
}
