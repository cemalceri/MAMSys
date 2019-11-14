using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities;

namespace MAMSys.Entites.Concrete
{
    public class Canli:IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int AnneId { get; set; }
        public int BabaId { get; set; }
        public int DurumId { get; set; }
        public string KimlikNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime OlumTarihi { get; set; }
        public int CinsId { get; set; }
        public int TurId { get; set; }
        public int IrkId { get; set; }
        public bool Cinsiyeti { get; set; }
        public int DogumTipiId { get; set; }




    }
}
