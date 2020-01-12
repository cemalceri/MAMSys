using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Abstract
{
    public interface IKullaniciService
    {
        List<Rol> GetRols(Kullanici kullanici);
        Kullanici Add(Kullanici kullanici);
        Kullanici GetirByMail(string mail);
    }
}
