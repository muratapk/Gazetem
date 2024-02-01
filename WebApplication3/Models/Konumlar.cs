using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Konumlar
    {
        [Key]
        public int KonumId { get; set; }
        public string KonumAdi { get; set; } = string.Empty;
        public virtual List<Haberler>? Habers { get; set; }
        public virtual List<Reklam>? Reklamlars { get; set; }
    }
}
