using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MAMSys.Core.Extensions
{
    public static class ClaimExtension
    {
        public static void MailEkle(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(ClaimTypes.Email, email));
        }

        public static void AdEkle(this ICollection<Claim> claims, string ad)
        {
            claims.Add(new Claim(ClaimTypes.Name, ad));
        }

        public static void IdEkle(this ICollection<Claim> claims, string id)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id));
        }

        public static void RolEkle(this ICollection<Claim> claims, string[] roller)
        {
            foreach (var rol in roller)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

        }
    }
}
