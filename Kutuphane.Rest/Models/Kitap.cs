namespace Kutuphane.Rest.Models
{
    public class Kitap
    {
        public int ID { get; set; }
        
        public string Adi { get; set; }=String.Empty;
        public string Yazari { get; set; } = String.Empty;
        public string Türü { get; set; } = String.Empty;
        public DateTime BasimTarihi { get; set; }
        public int SayfaSayisi { get; set; }
        public string YayinEvi { get; set; }
        public int Durumu { get; set; }
    }
}
