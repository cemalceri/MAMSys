using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using MAMSys.Core.CrossCuttingConcern.Caching;
using MAMSys.Core.Utilities.Interceptors;
using MAMSys.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace MAMSys.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation ınvocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
