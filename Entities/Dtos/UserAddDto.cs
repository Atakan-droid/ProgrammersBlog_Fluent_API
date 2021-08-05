﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemeli !")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string UserName { get; set; }
        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} Boş Geçilmemeli !")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} Boş Geçilmemeli !")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} Boş Geçilmemeli !")]
        [MaxLength(13, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(13, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DisplayName("Resim")]
        [Required(ErrorMessage = "Litfen Bir {0} Ekleyiniz !")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string Picture { get; set; }
    }
}