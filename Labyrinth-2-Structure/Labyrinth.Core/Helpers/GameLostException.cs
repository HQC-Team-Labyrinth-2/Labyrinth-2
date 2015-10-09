namespace Labyrinth.Core.Helpers
{
    using System;

    public class GameLostException : Exception
    {
        public GameLostException()
        {
        }

        public GameLostException(string message)
            : base(message)
        {
        }

        public GameLostException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
