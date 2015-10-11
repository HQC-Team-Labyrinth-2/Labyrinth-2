namespace Labyrinth.Core.Helpers.CustomExceptions
{
    using System;

    /// <summary>
    /// Custom exception class for invalid player's position
    /// </summary>
    public class InvalidPlayerPositionException : Exception
    {
        /// <summary>
        /// Constructor with 1 parameter
        /// </summary>
        /// <param name="message">String, which represents the error message</param>
        public InvalidPlayerPositionException(string message)
            : base(message)
        {
        }
    }
}
