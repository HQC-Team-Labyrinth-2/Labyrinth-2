using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.Common.Logger
{
    public sealed class ConsoleLogger
    {
        private static ConsoleLogger logger = null;

        private ConsoleLogger()
        {
        }

        public static ConsoleLogger Instance()
        {
            if (logger == null)
            {
                logger = new ConsoleLogger();
            }
            return logger;
        }

        public void Log(string message)
        {
            Console.WriteLine("Time:{0} Message:{1}", DateTime.Now, message);
        }
    }
}
