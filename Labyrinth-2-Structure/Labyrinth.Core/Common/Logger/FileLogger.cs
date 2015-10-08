namespace Labyrinth.Core.Common.Logger
{
    using System;
    using System.IO;

    public sealed class FileLogger : ILogger
    {
        private static FileLogger logger = null;

        private FileLogger()
        {
        }

        public static FileLogger Instance()
        {
            if (logger == null)
            {
                logger = new FileLogger();
            }

            return logger;
        }

        public void Log(string message)
        {
            string fileName = "log.txt";

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, message);
            }

            string textToLog = string.Format("Time:{0} Message:{1}" + System.Environment.NewLine, DateTime.Now, message);
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + fileName, textToLog);
        }
    }
}
