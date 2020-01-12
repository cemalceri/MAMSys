﻿using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Business.Abstract;
using MAMSys.Business.Constants;
using MAMSys.Core.Entities.Concrete;
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

        public IDataResult<Kullanici> CreateUser(KullaniciKayitDto kullaniciKayitDto, string sifre)
        {
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

        public IDataResult<Kullanici> Login(KullaniciGirisDto kullaniciGirisDto)
        {
            var kullanici = _kullaniciService.GetirByMail(kullaniciGirisDto.Mail);
            if (kullanici == null)
            {
                return new ErrorDataResult<Kullanici>(Messages.KullaniciBulunamadi);
            }

            if (!HashingHelper.sifreHashDogrula(kullaniciGirisDto.Sifre, kullanici.Sifre, kullanici.SifreTuzu))
            {
                return new ErrorDataResult<Kullanici>(Messages.SifreHatali);
            }
            return new SuccessDataResult<Kullanici>(kullanici, Messages.GirisBasarili);
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
            var accesToken = _tokenHelper.CreateToken(kullanici, roller);
            return new SuccessDataResult<AccessToken>(accesToken, Messages.AccesTokenOlusturuldu);
        }
    }
}
