using System.Collections.Generic;
using Labyrinth.Core.Player.Contracts;

namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.PlayField.Contracts;

    public class PlayField : IPlayField, IMemorizable
    {
        private ICell[,] playField;
        private IPlayFieldGenerator playFieldGenerator;

        public PlayField(
            IPlayFieldGenerator generator,
            IPosition playerPosition,
            int rows = Constants.StandardGameLabyrinthRows,
            int colums = Constants.StandardGameLabyrinthCols)
        {
            this.playFieldGenerator = generator;
            this.NumberOfRows = rows;
            this.NumberOfCols = colums;
            this.PlayerPosition = playerPosition;
        }

        public IPosition PlayerPosition { get; private set; }

        //TODO: validation
        public int NumberOfRows
        {
            get;
            private set;
        }

        //TODO: validation
        public int NumberOfCols
        {
            get;
            private set;
        }

        public void InitializePlayFieldCells(IRandomGenerator random)
        {
            this.playField = this.playFieldGenerator.GeneratePlayField(random);
        }

        public ICell GetCell(IPosition position)
        {
            return this.playField[position.Row, position.Column];
        }

        //TODO Validate Remove player position
        public void RemovePlayer(IPlayer player)
        {
            this.playField[player.CurentCell.Position.Row, player.CurentCell.Position.Column].ValueChar = Constants.StandardGameCellEmptyValue;
        }

        public void AddPlayer(IPlayer player, IPosition position)
        {
            player.CurentCell = this.playField[position.Row, position.Column];
            this.playField[position.Row, position.Column].ValueChar = Constants.StandardGamePlayerChar;
            this.PlayerPosition = position;
        }

        public IMemento SaveMemento()
        {
            return new PlayFieldMemento(this.playField, this.PlayerPosition);
        }

        public void RestoreMemento(IMemento memento)
        {
            this.playField = memento.PlayField;
            this.PlayerPosition = memento.PlayerPosition;
        }
    }
}
