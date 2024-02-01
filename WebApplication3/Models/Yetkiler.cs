using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Yetkiler


    {
        [Key]
        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; } = string.Empty;
        public virtual List<Kulanıcılar>? Kulanıcılars { get; set; }

    }
}
