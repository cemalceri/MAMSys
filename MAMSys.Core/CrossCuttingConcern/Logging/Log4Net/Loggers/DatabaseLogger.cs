using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.CrossCuttingConcern.Logging.Log4Net.Loggers
{
    class DatabaseLogger:LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger") // log4net.config deki isim
        {
        }
    }
}
