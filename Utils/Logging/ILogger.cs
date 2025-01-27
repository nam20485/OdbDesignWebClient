﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Logging
{
    public interface ILogger
    {
        //LoggerBase.Level LogLevel { get; set; }

        void Start(LoggerBase.Level level);
        void Stop();

        void Log(LoggerBase.Level level, string message, params object[] @params);
        void Trace(string message, params object[] @params);
        void Debug(string message, params object[] @params);
        void Warn(string message, params object[] @params);
        void Info(string message, params object[] @params);
        void Error(string message, params object[] @params);
        void Exception(Exception e);
    }
}
