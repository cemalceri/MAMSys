using MAMSys.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Entites.Concrete
{
    public class RolKullanici:IEntity
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int KullaniciId { get; set; }
    }
}
