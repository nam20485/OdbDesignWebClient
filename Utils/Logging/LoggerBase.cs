using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Logging
{
    public abstract class LoggerBase : ILogger
    {
        public enum Level
        {
            Trace,
            Debug,
            Info,
            Warn,
            Error,
            None
        }

        private const string MessageFormat = "[{0:yyyy-MM-dd HH:mm:ss.fff} - [{1}] {2}";

        public Level LogLevel { get; set; }

        public LoggerBase(Level level)
        {
            LogLevel = level;
        }

        protected abstract void WriteMessage(string message);

        public virtual void Log(Level level, string message, params object[] @params)
        {
            if (level >= LogLevel)
            {
                var formatted = FormatMessage(level, DateTime.UtcNow, message, @params);
                WriteMessage(formatted);              
            }
        }        

        private string FormatMessage(Level level, DateTime utcNow, string message, object[] @params)
        {
            var msg = string.Format(message, @params);
            return string.Format(MessageFormat, utcNow, level, msg);
        }

        public void Debug(string message, params object[] @params)
        {
            Log(Level.Debug, message, @params);
        }

        public void Error(string message, params object[] @params)
        {
            Log(Level.Error, message, @params);
        }

        public void Info(string message, params object[] @params)
        {
            Log(Level.Info, message, @params);
        }

        public void Trace(string message, params object[] @params)
        {
            Log(Level.Trace, message, @params);
        }

        public void Warn(string message, params object[] @params)
        {
            Log(Level.Warn, message, @params);
        }
    }
}
