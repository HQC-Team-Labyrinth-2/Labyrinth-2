namespace Labyrinth.Core.Common.Logger
{
    using System;

    public sealed class ConsoleLogger : ILogger
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
