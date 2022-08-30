using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Rest.Models
{
    public class UyeBilgileri
    {
        public UyeBilgileri()
        {
            KayitTarihi = DateTime.Now;
        }
        public int ID { get; set; }
        public string Ad { get; set; } = String.Empty;
        public string Soyad { get; set; } = String.Empty;
        public string KullaniciAdi { get; set; } =  String.Empty;
        public string Sifre { get; set; }
        [NotMapped]
        public string SifreTekrar { get; set; } 
        public DateTime KayitTarihi { get; set; }
        public string UyeDurumu { get; set; } = String.Empty;
        public bool  Admin { get; set; }

    }
}
