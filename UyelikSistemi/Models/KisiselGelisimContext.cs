using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UyelikSistemi.Models
{
    public class KisiselGelisimContext : DbContext
    {
        public KisiselGelisimContext() : base("name=KisiselGelisimContext")
        {

        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}