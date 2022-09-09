using System.Collections.Generic;


namespace Kutuphane.Rest.Models
{
    public class UyeBilgileri:BaseEntity
    {
        public UyeBilgileri()
        {
            KayitTarihi = DateTime.Now;
          

        }
       
        public string Ad { get; set; } = String.Empty;
        public string Soyad { get; set; } = String.Empty;
        public string KullaniciAdi { get; set; } =  String.Empty;
        public string Sifre { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool IsDeleted { get; set; }
        public bool  Admin { get; set; }


        //relational property
        public virtual ICollection<KitapHareket> KitapHarekets { get; set; }


    }
}
