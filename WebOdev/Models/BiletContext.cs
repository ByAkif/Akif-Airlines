using Microsoft.EntityFrameworkCore;
using Web12412412.Models;

namespace Web12412412.Models
{
    public class BiletContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Deneme;Trusted_Connection=True;");
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Bilet> Biletler { get; set; }

        public DbSet<Ucak> Ucaklar { get; set; }

        public DbSet<Admin> Adminler { get; set; }

        public DbSet<Ucus> Ucuslar { get; set; }

        public DbSet<Web12412412.Models.Sehir>? Sehir { get; set; }


    }
}
