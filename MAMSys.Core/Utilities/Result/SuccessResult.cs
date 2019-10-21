using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.Utilities.Result
{
    class SuccessResult:Result
    {
        public SuccessResult(bool success, string message) : base(true, message)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
