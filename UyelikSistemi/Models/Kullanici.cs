using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UyelikSistemi.Models
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string KullaniciAd { get; set; }
        [Required]
        [StringLength(128)]
        public string ParolaHash { get; set; }
    }
}