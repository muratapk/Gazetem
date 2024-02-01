using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Resimler
    {
        [Key]
        public int ResimId { get; set; }
        public string ResimAd { get; set; } = string.Empty;
        public virtual List<Haberler>? Haberlers { get; set; }
    }
}
