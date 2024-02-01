using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Yazarlar
    {
        [Key]
        public int YazarId { get; set; }
        public string YazarAd { get; set; }= string.Empty;
        public string YazarResim { get; set; } = string.Empty;
        public string YazarEmail { get; set; } = string.Empty;
        public string YazarSifre { get; set; }= string.Empty;
        public virtual List<Haberler>? Habers { get; set; }
        [NotMapped]
        public IFormFile? YazarImage { get; set; }   
    }
}
