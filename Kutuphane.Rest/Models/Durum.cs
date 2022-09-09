namespace Kutuphane.Rest.Models
{
    public class Durum : BaseEntity
    {

        public string Aciklama { get; set; }
        //relational property
        public virtual ICollection<Kitap> Kitaps { get; set; }
    }
}
