using log4net;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger
{
    public class DatabaseLogger:LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }
    }
}
