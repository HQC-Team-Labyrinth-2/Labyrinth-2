namespace Labyrinth.Core.Input.Contracts
{
    /// <summary>
    /// Interface for providing info input
    /// </summary>
    public interface IInfoInputProvider
    {
        /// <summary>
        /// Method that gets from the UI the player's name as a string
        /// </summary>
        string GetPlayerName();

        /// <summary>
        /// Method that gets from the UI the dimensions of the chosen playfield
        /// </summary>
        int GetPlayFieldDimensions();
    }
}
