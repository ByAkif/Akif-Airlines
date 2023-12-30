using Microsoft.EntityFrameworkCore;


namespace WebOdev.Models
{
    public class BiletContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=WebOdev;Trusted_Connection=True;");
        }
        public DbSet<Ucak> Ucaklar { get; set; }
        public DbSet<Bilet> Biletler { get; set; }
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
