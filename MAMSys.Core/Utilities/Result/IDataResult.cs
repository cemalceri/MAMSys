using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.Utilities.Result
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
