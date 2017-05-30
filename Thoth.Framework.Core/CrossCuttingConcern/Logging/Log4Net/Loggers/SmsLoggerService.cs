using log4net;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class SmsLoggerService : LoggerService
    {
        public SmsLoggerService()
            : base(LogManager.GetLogger("SmsLogger"))
        {
        }
    }
}
