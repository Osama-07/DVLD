using System.Diagnostics;


namespace DrivingDataAccess
{
    public class clsUtilSettings
    {
        public enum enEventType { Information = 1, Warning = 2, Error = 3 }

        public static void StoreEventInEventLogs(string Message, enEventType EventType)
        {
            string SourceName = "DVLD";

            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            switch (EventType)
            {
                case enEventType.Information:
                    EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Information);
                    break;
                case enEventType.Warning:
                    EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Warning);
                    break;
                case enEventType.Error:
                    EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
                    break;
                default:
                    EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
                    break;
            }
        }


    }
}
