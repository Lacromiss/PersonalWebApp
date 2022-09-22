using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWebApp.Models
{
    public class Profil
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bos buraxmaq olmaz")]
        [MaxLength(50,ErrorMessage ="max limit 50 dir")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(50, ErrorMessage = "max limit 50 dir")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz"),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz"),DataType(DataType.PhoneNumber)]
        [MaxLength(50, ErrorMessage = "max limit 50 dir")]
        public string Phone { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public List<Science> Sciences { get; set; }
    }
}
