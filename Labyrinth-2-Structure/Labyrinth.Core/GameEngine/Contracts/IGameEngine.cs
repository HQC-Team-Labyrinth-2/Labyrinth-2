using Labyrinth.Core.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Common.Contracts;

namespace Labyrinth.Core.GameEngine.Contracts
{
   public interface IGameEngine
    {
        void Initialize(IRandomGenerator random);

        void Start();
    }
}
