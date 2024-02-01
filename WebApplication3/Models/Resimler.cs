using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Resimler
    {
        [Key]
        public int ResimId { get; set; }
        public string ResimAd { get; set; } = string.Empty;
        [ForeignKey("Haberler")]
        public int ? HaberId { get; set; }
        public Haberler? Haberler { get; set; }
       
    }
}
