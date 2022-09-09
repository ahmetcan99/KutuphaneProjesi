using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Rest.Models
{
    public class KitapHareket:BaseEntity
    {
   
        public int KitapID { get; set; }
        public int UyeBilgileriID { get; set; }
        public DateTime Tarih { get; set; }
        public int HareketYonu { get; set; }
        public string Hareket { get; set; }

        //relational property
        public virtual UyeBilgileri UyeBilgileri { get; set; }
        public virtual Kitap Kitap { get; set; }
    }
}
