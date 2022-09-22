using System.ComponentModel.DataAnnotations;

namespace PersonalWebApp.Models
{
    public class Me
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bos buraxmaq olmaz")]
        [MaxLength(105,ErrorMessage ="max limiti kecibsiz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(105, ErrorMessage = "max limiti kecibsiz")]
        public string Description { get; set; }
    }
}
