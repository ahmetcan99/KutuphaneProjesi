using Kutuphane.Rest.Models;

namespace Kutuphane.Rest.Dto
{
    public class KitapDto
    {
        public int ID { get; set; }
        public string Adi { get; set; } = String.Empty;
        public string Yazari { get; set; } = String.Empty;
        public string Türü { get; set; } = String.Empty;
        public DateTime BasimTarihi { get; set; }
        public int SayfaSayisi { get; set; }
        public int YayinEviId { get; set; }
        public int DurumID { get; set; }
        public bool IsDeleted { get; set; }

    }
}
