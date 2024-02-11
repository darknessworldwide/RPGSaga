using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7.RPGSaga
{
    internal class Logger
    {
        private static readonly string logFilePath = "game_log.txt";

        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(message);
            }
        }
    }
}
