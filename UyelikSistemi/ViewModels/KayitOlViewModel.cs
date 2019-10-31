using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UyelikSistemi.ViewModels
{
    public class KayitOlViewModel
    {
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Geçersiz e-mail adresi.")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Email { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage ="Lütfen bir parola belirtiniz.")]
        [MinLength(6, ErrorMessage = "Parola en az 6 karakterden oluşmalıdır.")]
        public string Parola { get; set; }

        [Display(Name = "Parola (Tekrar)")]
        [Required(ErrorMessage = "Lütfen parolayı tekrar giriniz.")]
        [Compare("Parola", ErrorMessage = "Girdiğiniz parolalar uyuşmuyor.")]
        public string ParolaTekrar { get; set; }
    }
}