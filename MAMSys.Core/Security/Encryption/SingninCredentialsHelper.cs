using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MAMSys.Core.Security.Encryption
{
   public  class SingninCredentialsHelper
    {
        public static SigningCredentials ImzaliKimlikOlustur(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
