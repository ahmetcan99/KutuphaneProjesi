namespace Kutuphane.Rest.Dto
{
    public class UyeBilgileriDto
    {
        public UyeBilgileriDto()
        {
            KayitTarihi = DateTime.Now;
           

        }
        public int ID { get; set; }
        public string Ad { get; set; } = String.Empty;
        public string Soyad { get; set; } = String.Empty;
        public string KullaniciAdi { get; set; } = String.Empty;
        public string Sifre { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool IsDeleted { get; set; }
        public bool Admin { get; set; }
    }
}
