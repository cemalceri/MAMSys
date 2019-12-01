using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MAMSys.Business.Abstract;
using MAMSys.Business.Concrete;
using MAMSys.Core.Utilities.Security.Jwt;
using MAMSys.DataAccess.Abstract;
using MAMSys.DataAccess.Concrete.EntityFramework;

namespace MAMSys.Business.DependecyResolver.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CanliManager>().As<ICanliServis>();
            builder.RegisterType<EfCanliDal>().As<ICanliDal>();

            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            builder.RegisterType<EfKullaniciDal>().As<IKullaniciDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


        }
    }
}
