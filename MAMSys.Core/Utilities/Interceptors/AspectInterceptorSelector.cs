using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using MAMSys.Core.Aspects.Autofac.Exception;
using MAMSys.Core.CrossCuttingConcern.Logging.Log4Net.Loggers;

namespace MAMSys.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes =
                type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes); // Metodların üzerindeki attribute leri ekle
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); // her metoda varsayılan olarak bu attribu
            return classAttributes.OrderBy(x => x.Priority).ToArray(); // öncelik sırasına göre methodun için çalıştır.
        }
    }
}
