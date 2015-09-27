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
           LabyrinthFacade.Start(new ConsoleRender(), new ConsoleInputProvider());
        }
    }
}
