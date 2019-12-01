using Microsoft.IdentityModel.Tokens;

namespace MAMSys.Core.Utilities.Security.Encryption
{
   public  class SingninCredentialsHelper
    {
        public static SigningCredentials ImzaliKimlikOlustur(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
