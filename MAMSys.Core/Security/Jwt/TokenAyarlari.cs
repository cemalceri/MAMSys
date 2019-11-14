using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MAMSys.Core.Security.Jwt
{
    public class TokenAyarlari
    {
        public string Izleme { get; set; }  
        public string Saglayici { get; set; }
        public int GecerlilikSuresi { get; set; }
        public string GuvenlikAnahtari { get; set; }


    }
}
