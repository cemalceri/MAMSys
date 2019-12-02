using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities;

namespace MAMSys.Entites.Dtos
{
    public class KullaniciGirisDto : IDto
    {
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }

        public string Sifre { get; set; }
    }
}
