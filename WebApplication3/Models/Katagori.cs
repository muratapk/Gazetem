using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Katagori
    {
        [Key]
        public int KatagoriId { get; set; }
        public string KatagoriAdi { get; set; } = string.Empty;
        public virtual List<Haberler>? Haberlers { get; set; }
    }
}
