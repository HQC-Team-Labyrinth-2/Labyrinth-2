using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Core;
using Labyrinth.Core.GameEngine;
using Labyrinth.ConsoleUI.Output;
using Labyrinth.ConsoleUI.Input;
using Labyrinth.Core.Common.Logger;
using Labyrinth.Core.Input.Contracts;
namespace Labyrinth.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            LabyrinthFacade.Start(new ConsoleRender(), new ConsoleInputProvider(), FileLogger.Instance());
        }
    }


}
