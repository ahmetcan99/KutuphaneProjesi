namespace Kutuphane.Rest.Models
{
    public class Kitap:BaseEntity
    {
        public Kitap()
        {
            IsDeleted = false;
        }
      

        public string Adi { get; set; } = String.Empty;
        public string Yazari { get; set; } = String.Empty;
        public string Türü { get; set; } = String.Empty;
        public DateTime BasimTarihi { get; set; }
        public int SayfaSayisi { get; set; }
        public int YayinEviId { get; set; }
        //public string YayinEvi { get; set; }
        public int DurumID { get; set; }
        public bool IsDeleted { get; set; }


        //relational property
        public virtual ICollection<KitapHareket> KitapHarekets { get; set; }
        public virtual Durum Durum { get; set; }
        public virtual YayinEvi YayinEvi { get; set; }
    }
}
