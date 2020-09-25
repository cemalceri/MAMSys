using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.CrossCuttingConcern.Logging
{
    class LogDetailWithException : LogDetail
    {
        public string ExceptionMessages { get; set; }
    }
}
