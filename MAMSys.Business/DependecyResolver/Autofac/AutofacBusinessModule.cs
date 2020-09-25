using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MAMSys.Business.Abstract;
using MAMSys.Business.Concrete;
using MAMSys.Core.Utilities.Interceptors;
using MAMSys.Core.Utilities.Security.Jwt;
using MAMSys.DataAccess.Abstract;
using MAMSys.DataAccess.Concrete.EntityFramework;

namespace MAMSys.Business.DependecyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CanliManager>().As<ICanliServis>();
            builder.RegisterType<EfCanliDal>().As<ICanliDal>();

            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            builder.RegisterType<EfKullaniciDal>().As<IKullaniciDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}