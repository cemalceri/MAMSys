using System;

namespace MAMSys.Core.Utilities.Security.Jwt
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime GecerlilikTarihi { get; set; }
    }
}
