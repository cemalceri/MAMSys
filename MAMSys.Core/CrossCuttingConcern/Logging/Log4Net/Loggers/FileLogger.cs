using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    public class FileLogger:LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger") // log4net.config deki isim
        {
        }
    }
}
