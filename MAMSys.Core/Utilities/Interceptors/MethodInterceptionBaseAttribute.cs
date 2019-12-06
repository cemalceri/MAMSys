using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.Utilities.Interceptors
{
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
