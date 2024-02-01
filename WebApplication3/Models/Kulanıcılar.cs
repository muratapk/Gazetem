using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
namespace WebApplication3.Models
{
    public class Kulanıcılar
    {
        [Key]
        public int KulanıcıId { get; set; }
        public string KulaniciSifre { get; set; } = string.Empty;
        
        public string KulaniciAdi { get; set; } = string.Empty;
        [ForeignKey("Yetkiler")]
        public int YetkiId { get; set; }
        
        public virtual Yetkiler? Yetkiler { get; set; }
    }
}