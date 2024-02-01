using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Haberler
    {
        [Key]
        public int HaberId { get; set; }
        public string HaberBaslik { get; set; } = string.Empty;
        public string HaberKonu { get; set; } = string.Empty;
        public string Haberİcerik { get; set; } = string.Empty;
        [ForeignKey("Resimler")]
        public int ResimId { get; set; }
        public virtual Resimler? Resimler { get; set; }
        [ForeignKey("Katagori")]
        public int KatagoriId { get; set; }
        public virtual Katagori? Katagori{ get; set; }
        public int YazarId { get; set; }
        public virtual Yazarlar? Yazarlar { get; set; }
        public DateTime HaberTarihi { get; set; }
        public int HaberManset { get; set; }
        [ForeignKey("Konumlar")]
        public int KonumId { get; set; }
        public virtual Konumlar? Konumlar { get; set; }
        public virtual List<Yorumlar>? Yorumlars { get; set; }


    }
}
