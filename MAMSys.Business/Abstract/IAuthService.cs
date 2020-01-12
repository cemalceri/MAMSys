using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Utilities.Result;
using MAMSys.Core.Utilities.Security.Jwt;
using MAMSys.Entites.Dtos;

namespace MAMSys.Business.Abstract
{
   public interface IAuthService
   {
       IDataResult<Kullanici> CreateUser(KullaniciKayitDto kullaniciKayitDto, string password);
       IDataResult<Kullanici> Login(KullaniciGirisDto kullaniciGirisDto);
       IResult IsUserExist(string email);
       IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici);
   }
}
