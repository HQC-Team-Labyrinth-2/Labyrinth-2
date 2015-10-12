namespace Labyrinth.Core.Input.Contracts
{
    /// <summary>
    /// Interface for providing the commands input from the UI
    /// </summary>
    public interface ICommandInputProvider
    {
        /// <summary>
        /// Method that gets the chosen command from the UI
        /// </summary>
        string GetCommand();
    }
}
