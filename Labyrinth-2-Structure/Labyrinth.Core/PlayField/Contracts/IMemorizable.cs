namespace Labyrinth.Core.PlayField.Contracts
{
    /// <summary>
    /// Interface that obliges the implamentator to implement those methods in order to be saved
    /// </summary>
    public interface IMemorizable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMemento SaveMemento();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memento"></param>
        void RestoreMemento(IMemento memento);
    }
}
