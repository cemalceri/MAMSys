using MAMSys.Core.DataAccess;
using MAMSys.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.DataAccess.Abstract
{
    public interface IKullaniciDal : IEntityRepository<Kullanici>
    {
        List<Rol> RolGetir(Kullanici kullanici);
    }
}
