using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Reklam
    {
        [Key]
        public int ReklamId { get; set; } 
        public string ReklamKonusu { get; set; } = string.Empty;
        public string ReklamResim { get; set; } = string.Empty;
        [ForeignKey("Konum")]
        public int KonumId { get; set; }
        public virtual Konumlar? Konumlar { get; set; }
    }
}
