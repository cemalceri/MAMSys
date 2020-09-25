using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Utilities.Result;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Abstract
{
    public interface IKullaniciService
    {
        IDataResult<List<Rol>> GetRols(Kullanici kullanici);
        IDataResult<Kullanici> Add(Kullanici kullanici);
        IDataResult<Kullanici> GetirByMail(string mail);
    }
}
