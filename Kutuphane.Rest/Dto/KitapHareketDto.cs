namespace Kutuphane.Rest.Dto
{
    public class KitapHareketDto
    {
        public int ID { get; set; }
        public int KitapID { get; set; }
        public int UyeBilgileriID { get; set; }
        public DateTime Tarih { get; set; }
        public int HareketYonu { get; set; }
        public string Hareket { get; set; }
    }
}
