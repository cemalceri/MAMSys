using MAMSys.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Entites.Concrete
{
   public class Rol:IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
    }
}
