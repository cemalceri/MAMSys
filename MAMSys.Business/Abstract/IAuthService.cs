using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Security.Jwt;
using MAMSys.Core.Utilities.Result;
using MAMSys.Entites.Dtos;

namespace MAMSys.Business.Abstract
{
   public interface IAuthService
   {
       IDataResult<Kullanici> Kaydet(KullaniciKayitDto kullaniciKayitDto);
       IDataResult<Kullanici> Giris(KullaniciGirisDto kullaniciGirisDto);
       IResult KayitliMi(string email);
       IDataResult<AccessToken> AccessTokenOlustur(Kullanici kullanici);
   }
}
