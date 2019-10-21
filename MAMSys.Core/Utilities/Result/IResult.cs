using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.Utilities.Result
{
   public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
