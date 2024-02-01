using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Gazete
    {
        [Key]
        public int GazeteId { get; set; }
        public string GazeteAdi { get; set; } = string.Empty;
        public string GazeteLogo { get; set; } = string.Empty;
        public string GazeteSlogan { get; set; } = string.Empty;
        public string GazeteEmail { get; set; } = string.Empty;

        public string GazetFacebook { get; set; } = string.Empty;
        public string GazeteInstagram { get; set; } = string.Empty;
        public string GazeteYoutube { get; set; } = string.Empty;
        public string GazeteTelefon { get; set; } = string.Empty;
        public string GazeteAdres { get; set; } = string.Empty;
    }
}
