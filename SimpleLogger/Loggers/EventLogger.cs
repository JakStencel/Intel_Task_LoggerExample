using System.Diagnostics;

namespace SimpleLogger.Loggers
{
    public class EventLogger : IBaseLogger
    {
        public void Log(string message)
        {
            //I am basing on Application EventLog, there is a possibility to create new one
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message, EventLogEntryType.Information, 101, 1);
            }
        }
    }
}
