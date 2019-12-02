using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MAMSys.Core.Security.Jwt
{
    public class TokenAyarlari
    {
        public string Audience { get; set; }  
        public string Issuer { get; set; }
        public int Expiration { get; set; }
        public string SecurityKey { get; set; }


    }
}
