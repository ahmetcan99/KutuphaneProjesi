using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Rest.Models
{
    public class YayinEvi:BaseEntity
    {
        
        public string Adi { get; set; }

        //relational property
        public virtual ICollection<Kitap> Kitaps { get; set; }
        
    }
}
