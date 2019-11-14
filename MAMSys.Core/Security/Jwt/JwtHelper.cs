using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MAMSys.Core.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
     

        private TokenAyarlari _tokenAyarlari;
        private DateTime gecerlilikSuresi;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenAyarlari = Configuration.GetSection("TokenAyarlari").Get<TokenAyarlari>();
            gecerlilikSuresi = DateTime.Now.AddMinutes(_tokenAyarlari.GecerlilikSuresi);
        }


        public AccessToken CreateToken(Kullanici kullanici, List<Rol> roller)
        {
            var guvenlikAnahtari = SecurityKeyHelper.GuvenlikAnahtariOlustur(_tokenAyarlari.GuvenlikAnahtari);
            var ImzaliKimlik = SingninCredentialsHelper.ImzaliKimlikOlustur(guvenlikAnahtari);

        }

        public JwtSecurityToken JwtTokenOlustur(TokenAyarlari tokenAyarlari, Kullanici kullanici, SigningCredentials imzaliKimlik, List<Rol> roller)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenAyarlari.Saglayici,
                audience:tokenAyarlari.Izleme,
                expires:gecerlilikSuresi,
                notBefore:DateTime.Now,
                signingCredentials:imzaliKimlik,
                claims:RolAta()

                );

        }

        private IEnumerable<Claim> RolAta(Kullanici kullanici,List<Rol> roller)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(type:""));
        }
    }
}
