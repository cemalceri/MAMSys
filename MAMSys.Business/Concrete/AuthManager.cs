using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Business.Abstract;
using MAMSys.Business.Constants;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Security.Jwt;
using MAMSys.Core.Utilities.Result;
using MAMSys.Entites.Dtos;

namespace MAMSys.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _kullaniciService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService kullaniciService, ITokenHelper tokenHelper)
        {
            _kullaniciService = kullaniciService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Kullanici> Kaydet(KullaniciKayitDto kullaniciKayitDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kullanici> Giris(KullaniciGirisDto kullaniciGirisDto)
        {
            var kullanici = _kullaniciService.GetirByMail(kullaniciGirisDto.MailAdresi);
            if (kullanici==null)
            {
                return new  ErrorDataResult<Kullanici>(Messages.HayvanEklendi);
            }
        }

        public IResult KayitliMi(string email)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> AccessTokenOlustur(Kullanici kullanici)
        {
            throw new NotImplementedException();
        }
    }
}
