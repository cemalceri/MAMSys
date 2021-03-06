﻿using MAMSys.Core.DataAccess.EntityFramework;
using MAMSys.DataAccess.Abstract;
using MAMSys.DataAccess.Concrete.EntityFramework.Context;
using MAMSys.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using  System.Linq;
using MAMSys.Core.Entities.Concrete;


namespace MAMSys.DataAccess.Concrete.EntityFramework
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, MAMSysContext>, IKullaniciDal
    {
        public List<Rol> GetRols(Kullanici kullanici)
        {
            using (var context = new MAMSysContext())
            {
                var result = from rol in context.Rol
                    join rolKullanici in context.RolKullanici
                        on rol.Id equals rolKullanici.Id
                    where rolKullanici.Id == kullanici.Id
                    select new Rol {Id = rol.Id, Adi = rol.Adi};
                return result.ToList();
            }
        }
}
}
