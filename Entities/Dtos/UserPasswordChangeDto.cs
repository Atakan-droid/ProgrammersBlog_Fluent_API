using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Şu anki Şifreniz")]
        [Required(ErrorMessage = "{0} Boş Geçilmemeli !")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DisplayName("Yeni Şifreniz")]
        [Required(ErrorMessage = "{0} Boş Geçilmemeli !")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DisplayName("Yeni Şifrenizin Tekrarı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemeli !")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Girmiş olduğunuz Yeni Şifreniz ile Yeni Şifrenizin Tekrarı Birbiri ile uyuşmalıdır.")]
        public string RepeatPassword { get; set; }
    }
}
