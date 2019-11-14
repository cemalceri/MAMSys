namespace MAMSys.Core.Entities.Concrete
{
    public class RolKullanici:IEntity
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int KullaniciId { get; set; }
    }
}
