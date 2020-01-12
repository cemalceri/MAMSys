using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MAMSys.Core.Extensions
{
    public static class ClaimExtension
    {
        public static void AddMail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(ClaimTypes.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddId(this ICollection<Claim> claims, string id)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id));
        }

        public static void AddRole(this ICollection<Claim> claims, string[] rols)
        {
            foreach (var rol in rols)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

        }
    }
}
