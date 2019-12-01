using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Extensions;
using MAMSys.Core.Security.Jwt;
using MAMSys.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MAMSys.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }


        private TokenAyarlari _tokenAyarlari;
        private DateTime _gecerlilikTarihi;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenAyarlari = Configuration.GetSection("TokenAyarlari").Get<TokenAyarlari>();
            _gecerlilikTarihi = DateTime.Now.AddMinutes(_tokenAyarlari.GecerlilikSuresi);
        }


        public AccessToken CreateToken(Kullanici kullanici, List<Rol> roller)
        {
            var guvenlikAnahtari = SecurityKeyHelper.GuvenlikAnahtariOlustur(_tokenAyarlari.GuvenlikAnahtari);
            var imzaliKimlik = SingninCredentialsHelper.ImzaliKimlikOlustur(guvenlikAnahtari);
            var jwt = JwtTokenOlustur(_tokenAyarlari, kullanici, imzaliKimlik, roller);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken {Token = token, GecerlilikTarihi = _gecerlilikTarihi};
        }

        public JwtSecurityToken JwtTokenOlustur(TokenAyarlari tokenAyarlari, Kullanici kullanici, SigningCredentials imzaliKimlik, List<Rol> roller)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenAyarlari.Saglayici,
                audience: tokenAyarlari.Izleme,
                expires: _gecerlilikTarihi,
                notBefore: DateTime.Now,
                signingCredentials: imzaliKimlik,
                claims: ClaimGetir(kullanici, roller)
                );
            return jwt;
        }

        private IEnumerable<Claim> ClaimGetir(Kullanici kullanici, List<Rol> roller)
        {
            var claims = new List<Claim>();
            claims.AdEkle(kullanici.Adi + kullanici.Soyadi);
            claims.IdEkle(kullanici.Id.ToString());
            claims.MailEkle(kullanici.EMail);
            claims.RolEkle(roller.Select(x => x.Adi).ToArray());
            return claims;
        }
    }
}
