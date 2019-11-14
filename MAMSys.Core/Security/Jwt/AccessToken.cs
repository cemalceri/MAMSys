using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.Security.Jwt
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime BitisSuresi { get; set; }
    }
}
