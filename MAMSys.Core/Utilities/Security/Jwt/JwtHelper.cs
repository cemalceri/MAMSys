using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using MAMSys.Core.Entities.Concrete;
using MAMSys.Core.Extensions;
using MAMSys.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MAMSys.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }


        private TokenOptions _tokenOptions;
        private DateTime _accesTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
        }


        public AccessToken CreateToken(Kullanici kullanici, List<Rol> roller)
        {
            _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.Expiration);
            var securityKey = SecurityKeyHelper.GuvenlikAnahtariOlustur(_tokenOptions.SecurityKey);
            var singningCredentials = SingninCredentialsHelper.ImzaliKimlikOlustur(securityKey);
            var jwt = JwtTokenOlustur(_tokenOptions, kullanici, singningCredentials, roller);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken {Token = token, GecerlilikTarihi = _accesTokenExpiration};
        }

        public JwtSecurityToken JwtTokenOlustur(TokenOptions tokenOptions, Kullanici kullanici, SigningCredentials singningCredentials, List<Rol> rols)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accesTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: singningCredentials,
                claims: ClaimGetir(kullanici, rols)
                );
            return jwt;
        }

        private IEnumerable<Claim> ClaimGetir(Kullanici kullanici, List<Rol> rols)
        {
            var claims = new List<Claim>();
            claims.AddName(kullanici.Adi + kullanici.Soyadi);
            claims.AddId(kullanici.Id.ToString());
            claims.AddMail(kullanici.EMail);
            claims.AddRole(rols.Select(x => x.Adi).ToArray());
            return claims;
        }
    }
}
