using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Utilities.Result;

namespace MAMSys.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
