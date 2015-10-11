namespace Labyrinth.Core.Input.Contracts
{
    /// <summary>
    /// Interface for providing menu input
    /// </summary>
    public interface IMenuInputProvider
    {
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
