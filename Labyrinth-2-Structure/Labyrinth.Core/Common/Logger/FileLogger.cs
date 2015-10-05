using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.Common.Logger
{
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
            String fileName = "log.txt";
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, message);
            }

            String textToLog = String.Format("Time:{0} Message:{1}" + System.Environment.NewLine, DateTime.Now, message);
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + fileName,
                  textToLog);
        }
    }
}
