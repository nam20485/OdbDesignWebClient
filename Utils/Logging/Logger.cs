using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace Utils.Logging
{
    public static class Logger
    {
        private static readonly ILogger _logger = new ConsoleLogger();

        //public static LoggerBase.Level Level
        //{
        //    get => _logger.LogLevel;
        //    set => _logger.LogLevel = value;
        //}

        public static void Start(LoggerBase.Level level)
        {
            _logger.Start(level);
        }

        public static void Stop()
        {
            _logger.Stop();
        }

        public static void Trace(string message, params object[] @params)
        {
            _logger.Trace(message, @params);
        }

        public static void Debug(string message, params object[] @params)
        {
            _logger.Debug(message, @params);
        }

        public static void Warn(string message, params object[] @params)
        {
            _logger.Warn(message, @params);
        }

        public static void Info(string message, params object[] @params)
        {
            _logger.Info(message, @params);
        }

        public static void Error(string message, params object[] @params)
        {
            _logger.Error(message, @params);
        }

        public static void Exception(Exception e)
        {
            _logger.Exception(e);
        }
    }
}
