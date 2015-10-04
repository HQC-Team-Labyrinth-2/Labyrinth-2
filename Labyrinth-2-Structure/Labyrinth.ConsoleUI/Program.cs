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
using Labyrinth.Core.Input.Contracts;
using Labyrinth.Core.Output.Contracts;
using Ninject;
using Ninject.Modules;

namespace Labyrinth.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

           LabyrinthFacade.Start(new ConsoleRender(), new ConsoleInputProvider(),kernel);
        }   
    }

    public class Bindings:Core.Bindings
    {
        public override void Load()
        {
            Bind<IRenderer>().To<ConsoleRender>();
            Bind<IInputProvider>().To<ConsoleInputProvider>();
            base.Load();
        }
    }
    
}
