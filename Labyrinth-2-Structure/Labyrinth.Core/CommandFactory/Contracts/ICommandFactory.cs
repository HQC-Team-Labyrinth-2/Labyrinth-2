namespace Labyrinth.Core.CommandFactory.Contracts
{
    using Labyrinth.Core.Commands.Contracts;

    /// <summary>
    /// The interface of the CommandFactory
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Function for creating commands
        /// </summary>
        /// <param name="command">Command name</param>
        /// <returns>New command object</returns>
        ICommand CreateCommand(string command);
    }
}
