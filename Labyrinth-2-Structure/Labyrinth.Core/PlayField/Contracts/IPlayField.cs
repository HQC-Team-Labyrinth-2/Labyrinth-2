using Labyrinth.Core.Common;
using Labyrinth.Core.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: SOme of this methods shuld be moved in PlayFieldGenerator interface!
namespace Labyrinth.Core.PlayField.Contracts
{
    public interface IPlayField
    {
        int NumberOfRows { get; }

        int NumberOfCols { get; }

        void AddPlayer(ICharacter player, IPosition position);

        void RemovePlayer(ICharacter player, IPosition position);
        
        ICell GetCell(IPosition position);

        IPosition PlayerPosition { get; }

        bool TryMove(ICell cell, Direction direction);
    }
}
