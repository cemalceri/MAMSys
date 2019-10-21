using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities;

namespace MAMSys.Entites.Concrete
{
    public class Animal:IEntity
    {
        public long Id { get; set; }
        public string KimlikNo { get; set; }
        public string Adi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool Cinsiyeti { get; set; }
        public int IrkId { get; set; }



    }
}
