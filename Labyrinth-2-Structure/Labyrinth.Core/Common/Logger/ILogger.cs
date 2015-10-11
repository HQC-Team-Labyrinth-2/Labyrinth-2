namespace Labyrinth.Core.Common.Logger
{
    /// <summary>
    /// Interface for Logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Method for logging messages.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        void Log(string message);
    }
}
