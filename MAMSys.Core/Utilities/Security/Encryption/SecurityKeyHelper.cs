using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MAMSys.Core.Utilities.Security.Encryption
{
   public class SecurityKeyHelper
    {
        public static SecurityKey GuvenlikAnahtariOlustur(string guvenlikAnahtari)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(guvenlikAnahtari));
        }
    }
}
