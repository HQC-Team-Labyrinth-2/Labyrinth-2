namespace Labyrinth.Core.Commands.Contracts
{
    using Labyrinth.Core.Helpers.Contracts;

    /// <summary>
    /// Command interface
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// This method execute the command that implement it.
        /// </summary>
        /// <param name="commandContext">Command context contains all parametars that needs for the command to be executed.</param>
        void Execute(ICommandContext commandContext);

        /// <summary>
        /// Method that returns the name of the command.
        /// </summary>
        /// <returns>Name of the command</returns>
        string GetName();
    }
}
