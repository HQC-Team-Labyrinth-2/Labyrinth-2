using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Core.Common;
using Labyrinth.Core.PlayField.Contracts;

namespace Labyrinth.Core.PlayField
{
    public class PlayFieldMemento : IMemento
    {
        private ICell[,] playField;

        public PlayFieldMemento(IPlayField playField)
        {
            this.PlayField = playField.PlayFieldMatrix;
            this.PlayerPosition = new Position(playField.PlayerPosition.Row, playField.PlayerPosition.Column);
        }

        public ICell[,] PlayField
        {
            get
            {
                return this.playField;
            }
            set
            {
                if (value == null)
                {
                    //  throw  new NullReferenceException();
                }
                else
                {
                    if (this.playField == null)
                    {
                        this.playField = new ICell[value.GetLength(0), value.GetLength(1)];
                    }

                    for (int i = 0; i < value.GetLength(0); i++)
                    {
                        for (int j = 0; j < value.GetLength(1); j++)
                        {
                            this.playField[i, j] = (ICell)(((ICloneable)value[i, j]).Clone());
                        }
                    }
                }
            }
        }

        public IPosition PlayerPosition { get; set; }
    }
}
