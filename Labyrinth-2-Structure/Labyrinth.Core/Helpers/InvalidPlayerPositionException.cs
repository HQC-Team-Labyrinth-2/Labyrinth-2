namespace Labyrinth.Core.Helpers
{
    using System;

    public class InvalidPlayerPositionException : Exception
    {
        public InvalidPlayerPositionException()
        {
        }

        public InvalidPlayerPositionException(string message)
            : base(message)
        {
        }

        public InvalidPlayerPositionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
