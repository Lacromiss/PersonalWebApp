using System.ComponentModel.DataAnnotations;

namespace PersonalWebApp.Models
{
    public class Science
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bos buraxmaq olmaz")]
        [MaxLength(100,ErrorMessage ="max limit 100")]
        public string Name { get; set; }
        public int ProfilId { get; set; }

        public Profil Profil { get; set; }
    }
}
