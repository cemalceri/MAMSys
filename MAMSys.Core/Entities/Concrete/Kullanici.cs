namespace MAMSys.Core.Entities.Concrete
{
  public  class Kullanici:IEntity
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string OnEk { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TCKN { get; set; }
        public string EPosta { get; set; }
        public string EPosta2 { get; set; }
        public string GSM { get; set; }
        public string TelNo { get; set; }
        public string Faks { get; set; }
        public string SifreTuzu { get; set; }
        public string Sifre { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
        public int TipId { get; set; }
        public string AuthKey { get; set; }
        public string AuthType { get; set; }
        public string GizliSoru { get; set; }
        public string GizliCevap { get; set; }









    }
}
