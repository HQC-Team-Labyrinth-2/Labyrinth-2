namespace Labyrinth.Core.Input.Contracts
{
    /// <summary>
    /// Interface for providing the commands input from the console
    /// </summary>
    public interface ICommandInputProvider
    {
        /// <summary>
        /// Method that gets the chosen command from the console
        /// </summary>
        string GetCommand();
    }
}
