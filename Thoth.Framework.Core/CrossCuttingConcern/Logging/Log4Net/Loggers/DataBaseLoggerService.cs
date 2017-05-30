using log4net;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class DataBaseLoggerService : LoggerService
    {
        public DataBaseLoggerService()
            : base(LogManager.GetLogger("DataBaseLogger"))
        {
        }
    }
}
