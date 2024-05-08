using log4net;
using System;


namespace InventoryUtilits
{
    public class LogHelpers
    {
        private ILog log;
        public LogHelpers()
        {
            log = LogManager.GetLogger(this.GetType());
        }
        #region Log
        /// <summary>
        /// Log to write the logging content into the files
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void Log(LoggingLevels level, string message)
        {
            switch (level)
            {
                case LoggingLevels.Info:
                    log.Info(message);
                    break;
                case LoggingLevels.Error:
                    log.Error(message);
                    break;
                case LoggingLevels.Warn:
                    log.Warn(message);
                    break;
                case LoggingLevels.Fatal:
                    log.Fatal(message);
                    break;
                case LoggingLevels.Debug:
                    log.Debug(message);
                    break;
            }
        }
        #endregion

        #region Log
        /// <summary>
        /// Log to write the logging content into the files
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="exeption"></param>
        public void Log(LoggingLevels level, string message, Exception ex)
        {
            switch (level)
            {
                case LoggingLevels.Info:
                    log.Info(message, ex);
                    break;
                case LoggingLevels.Error:
                    log.Error(message, ex);
                    break;
                case LoggingLevels.Warn:
                    log.Warn(message, ex);
                    break;
                case LoggingLevels.Fatal:
                    log.Fatal(message, ex);
                    break;
                case LoggingLevels.Debug:
                    log.Debug(message, ex);
                    break;
            }
        }
        #endregion
    }

    public enum LoggingLevels
    {
        Info,
        Error,
        Fatal,
        Warn,
        Debug
    }
}

        