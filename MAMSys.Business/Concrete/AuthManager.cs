using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Business.Abstract;
using MAMSys.Business.Constants;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Utilities.Business;
using MAMSys.Core.Utilities.Result;
using MAMSys.Core.Utilities.Security.Hashing;
using MAMSys.Core.Utilities.Security.Jwt;
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

        public IResult CreateUser(KullaniciKayitDto kullaniciKayitDto, string sifre)
        {
            IResult result = BusinessRules.Run(IsMailAddressExist(kullaniciKayitDto.Mail));
            if (result!=null)
            {
                return result;
            }
            byte[] sifreHash, sifreTuz;
            HashingHelper.sifreHashOlustur(sifre, out sifreHash, out sifreTuz);
            var kullanici = new Kullanici
            {
                EMail = kullaniciKayitDto.Mail,
                Adi = kullaniciKayitDto.Adi,
                Soyadi = kullaniciKayitDto.Soyadi,
                Sifre = sifreHash,
                SifreTuzu = sifreTuz,
                Durum = true,
                TipId = 1
            };
            _kullaniciService.Add(kullanici);
            return new SuccessDataResult<Kullanici>(kullanici, Messages.KullaniciKaydedildi);
        }

        public IResult Login(KullaniciGirisDto kullaniciGirisDto)
        {
            var kullanici = _kullaniciService.GetirByMail(kullaniciGirisDto.Mail);
            if (kullanici == null)
            {
                return new ErrorResult(Messages.KullaniciBulunamadi);
            }

            if (!HashingHelper.sifreHashDogrula(kullaniciGirisDto.Sifre, kullanici.Data.Sifre, kullanici.Data.SifreTuzu))
            {
                return new ErrorResult(Messages.SifreHatali);
            }
            return new SuccessResult();
        }

        public IResult IsUserExist(string email)
        {
            if (_kullaniciService.GetirByMail(email) != null)
            {
                return new ErrorResult(Messages.KullaniciKayitli);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici)
        {
            var roller = _kullaniciService.GetRols(kullanici);
            var accesToken = _tokenHelper.CreateToken(kullanici, roller.Data);
            return new SuccessDataResult<AccessToken>(accesToken, Messages.AccesTokenOlusturuldu);
        }

        private IResult IsMailAddressExist(string mailAddress)
        {
            return  _kullaniciService.GetirByMail(mailAddress);
        }
    }
}
