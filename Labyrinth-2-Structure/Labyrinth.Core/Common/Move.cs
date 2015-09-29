namespace Labyrinth.Core.Common
{
    using System;

    public class Move
    {
        public Move(Position from, Position to)
        {
            this.From = from;
            this.To = to;
        }

        public Position From { get; private set; }

        public Position To { get; private set; }
    }

}

