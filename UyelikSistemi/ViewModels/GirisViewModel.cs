using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UyelikSistemi.ViewModels
{
    public class GirisViewModel
    {
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Geçersiz e-mail adresi.")]
        [Required(ErrorMessage = "Bir e-mail gir.")]
        public string Email { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Bir şifre gir.")]
        public string Parola { get; set; }
    }
}