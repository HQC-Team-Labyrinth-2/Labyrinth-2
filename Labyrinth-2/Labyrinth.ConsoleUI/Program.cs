using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Core;
using Labyrinth.Core.GameEngine;
using Labyrinth.ConsoleUI.Output;
using Labyrinth.ConsoleUI.Input;

namespace Labyrinth.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
               GameEngine gameEngine = new GameEngine(new ConsoleRender(),new ConsoleInputProvider());
               
                var gameInitializationStrategy = new StandardGameInitializationStrategy();

                gameEngine.Initialize(gameInitializationStrategy);

                gameEngine.Start();
            }
        }
    }
}
