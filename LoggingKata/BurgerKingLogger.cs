using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class BurgerKingLogger : ILog
    {
        public void LogDebug(string log)
        {
            Console.WriteLine($"Warning: {log}");
        }

        public void LogError(string log, Exception exception = null)
        {
            Console.WriteLine($"Fatal: {log}, Exception {exception}");
        }

        public void LogFatal(string log, Exception exception = null)
        {
            Console.WriteLine($"Fatal: {log}, Exception {exception}");
        }

        public void LogInfo(string log)
        {
            Console.WriteLine($"Info: {log}");
        }

        public void LogWarning(string log)
        {
            Console.WriteLine($"Warning: {log}");
        }
    }
}
