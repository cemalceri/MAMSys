using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MAMSys.Business.Abstract;
using MAMSys.Business.Concrete;
using MAMSys.DataAccess.Abstract;
using MAMSys.DataAccess.Concrete.EntityFramework;

namespace MAMSys.Business.DependecyResolver.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnimalManager>().As<IAnimalService>();
            builder.RegisterType<EfAnimalDal>().As<IAnimalDal>();
        }
    }
}
