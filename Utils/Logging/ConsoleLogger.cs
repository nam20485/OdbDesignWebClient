using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Logging
{
    public class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger(Level level)
            : base(level)
        {
        }

        protected override void LogMessage(string message, params object[] @params)
        {
            Console.Out.WriteLine(message, @params);            
        }
    }    
}
