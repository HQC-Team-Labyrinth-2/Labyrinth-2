namespace Labyrinth.ConsoleUI.Output
{
    using System;
    using Labyrinth.Core.Output.Contracts;

    public class InfoPanel : IInfoRenderer
    {
        public void ShowInfo(string infoMesage)
        {
            Console.WriteLine(infoMesage);
        }
    }
}
