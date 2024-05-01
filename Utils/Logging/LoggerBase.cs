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

        public Level LogLevel { get; } = Level.Info;

        public LoggerBase(Level level)
        {
            LogLevel = level;
        }

        protected abstract void LogMessage(string message, params object[] @params);

        public virtual void Log(Level level, string message, params object[] @params)
        {
            if (level >= LogLevel)
            {
                LogMessage(message, @params);
            }
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
