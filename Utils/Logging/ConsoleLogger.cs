using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Logging
{
    public class ConsoleLogger : LoggerBase
    {
        //public ConsoleLogger()
        //    : this(Level.Info)
        //{
        //}

        //public ConsoleLogger(Level level)
        //    : base(level)
        //{
        //}

        protected override void WriteMessage(string message)
        {
            Console.Out.WriteLine(message);            
        }
    }    
}
