using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneProjesi.Models
{
    public class UserInfo
    {
        public int ID { get; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [NotMapped]
        public string PasswordRepeat { get; set; } = string.Empty;
    }
}
