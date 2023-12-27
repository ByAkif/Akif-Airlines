using System.Collections.Generic;

namespace WebOdev.Models
{
    public class UcakRezervasyonDbContext : DbContext
    {
        public DbSet<Ucak> Ucaklar { get; set; }
        public DbSet<Guzergah> Guzergahlar { get; set; }
        public DbSet<Koltuk> Koltuklar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı bağlantı bilgilerini ayarlayın.
            optionsBuilder.UseSqlServer("your_connection_string_here");
        }
    }

}
