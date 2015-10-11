namespace Labyrinth.Core.Helpers.CustomExceptions
{
    using System;

    /// <summary>
    /// Custom exception class for invalid commands
    /// </summary>
    public class InvalidCommandException : Exception
    {
        /// <summary>
        /// Constructor with 1 parameter
        /// </summary>
        /// <param name="message">String that represents the error message</param>
        public InvalidCommandException(string message)
            : base(message)
        {
        }
    }
}
