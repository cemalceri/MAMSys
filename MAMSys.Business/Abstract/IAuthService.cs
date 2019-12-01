using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Security.Jwt;
using MAMSys.Core.Utilities.Result;
using MAMSys.Core.Utilities.Security.Jwt;
using MAMSys.Entites.Dtos;

namespace MAMSys.Business.Abstract
{
   public interface IAuthService
   {
       IDataResult<Kullanici> Kaydet(KullaniciKayitDto kullaniciKayitDto, string sifre);
       IDataResult<Kullanici> Giris(KullaniciGirisDto kullaniciGirisDto);
       IResult KullaniciVarMi(string email);
       IDataResult<AccessToken> AccessTokenOlustur(Kullanici kullanici);
   }
}
