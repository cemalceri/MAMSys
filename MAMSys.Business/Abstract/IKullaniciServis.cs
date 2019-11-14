using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Abstract
{
    public interface IKullaniciServis
    {
        List<Rol> RolGetir(Kullanici kullanici);
        Kullanici Ekle(Kullanici kullanici);
        Kullanici GetirMailIle(string mail);
    }
}
