using log4net;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class ConsoleLoggerService : LoggerService
    {
        public ConsoleLoggerService()
            : base(LogManager.GetLogger("ConsoleLogger"))
        {
        }
    }
}
