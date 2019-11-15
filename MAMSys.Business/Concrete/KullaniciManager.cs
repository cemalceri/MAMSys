﻿using MAMSys.Business.Abstract;
using MAMSys.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.DataAccess.Abstract;

namespace MAMSys.Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }
        public Kullanici Ekle(Kullanici kullanici)
        {
           return _kullaniciDal.Ekle(kullanici);
        }

        public Kullanici GetirByMail(string mail)
        {
            return _kullaniciDal.Getir(t => t.EPosta == mail);
        }

        public List<Rol> RolGetir(Kullanici kullanici)
        {
           return _kullaniciDal.RolGetir(kullanici);
        }
    }
}
