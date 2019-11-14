using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities;

namespace MAMSys.Entites.Dtos
{
    public class KullaniciKayitDto : IDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
    }
}
