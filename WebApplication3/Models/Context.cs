using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Context:DbContext
    {
        public DbSet<KargoSirketi> KargoSirketi { get; set; }
        public DbSet<Kargocu> Kargocu { get; set; }
        public DbSet<Durum> Durum { get; set; }
        public DbSet<Kargo> Kargo { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }

        public Context() : base("connectionString1")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}