using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.DependencyResolver;
using MAMSys.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace MAMSys.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, CoreModule[] modules)
        {
            foreach (var module in modules)
            {
             module.Load(services);   
            }

            return ServiceTool.Create(services);
        }
    }
}
