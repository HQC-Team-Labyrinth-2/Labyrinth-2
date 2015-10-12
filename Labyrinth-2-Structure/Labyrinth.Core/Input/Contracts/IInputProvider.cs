namespace Labyrinth.Core.Input.Contracts
{
    using Labyrinth.Core.Output.Contracts;

    /// <summary>
    /// Interface for providing input from the console
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Method that gets the chosen command from the console
        /// </summary>
        string GetCommand();

        /// <summary>
        /// Method that gets from the console the player's name as a string
        /// </summary>
        string GetPlayerName();

        /// <summary>
        /// Method that gets from the console the dimensions of the chosen playfield
        /// </summary>
        int GetPlayFieldDimensions();
    }
}
