using log4net;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class EventLoggerService : LoggerService
    {
        public EventLoggerService()  : base(LogManager.GetLogger("EventLogger"))
        {
        }
    }
}
