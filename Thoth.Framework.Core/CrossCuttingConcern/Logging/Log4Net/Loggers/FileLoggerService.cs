using log4net;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class FileLoggerService : LoggerService
    {
        public FileLoggerService() : base(LogManager.GetLogger("FileLogger"))
        {
        }
    }
}
