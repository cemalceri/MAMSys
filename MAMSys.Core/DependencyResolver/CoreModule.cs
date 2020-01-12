using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MAMSys.Core.CrossCuttingConcern.Caching;
using MAMSys.Core.CrossCuttingConcern.Caching.Microsoft;
using MAMSys.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MAMSys.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();


        }
    }
}
