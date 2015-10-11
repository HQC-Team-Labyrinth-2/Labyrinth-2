namespace Labyrinth.Core.Output.Contracts
{
    /// <summary>
    /// Interface that renders the information from the console
    /// </summary>
    public interface IInfoRenderer
    {
        /// <summary>
        /// Method that displays a given message on the console
        /// </summary>
        /// <param name="infoMesage">String that represents the information to be displayed</param>
        void ShowInfo(string infoMesage);
    }
}
