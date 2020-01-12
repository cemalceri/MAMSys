using MAMSys.Business.Abstract;
using MAMSys.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Aspects.Autofac.Caching;
using MAMSys.Core.Aspects.Autofac.Logging;
using MAMSys.Core.CrossCuttingConcern.Logging.Log4Net.Loggers;
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
        public Kullanici Add(Kullanici kullanici)
        {
            return _kullaniciDal.Add(kullanici);
        }
        [LogAspect(typeof(FileLogger))]
        public Kullanici GetirByMail(string mail)
        {
            return _kullaniciDal.Get(t => t.EMail == mail);
        }

        [CacheAspect(1)]
        public List<Rol> GetRols(Kullanici kullanici)
        {
            return _kullaniciDal.GetRols(kullanici);
        }
    }
}
