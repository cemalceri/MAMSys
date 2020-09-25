using MAMSys.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using MAMSys.Core.CrossCuttingConcern.Logging;
using MAMSys.Core.CrossCuttingConcern.Logging.Log4Net;
using MAMSys.Core.Utilities.Messages;

namespace MAMSys.Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = Activator.CreateInstance(loggerService) as LoggerServiceBase;
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessages = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            LogDetailWithException logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };
            return logDetailWithException;
        }
    }
}
