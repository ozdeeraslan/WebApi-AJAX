using Microsoft.EntityFrameworkCore;

namespace WebApiGorevler.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }
        public DbSet<Araba> Arabalar { get; set; }

        public DbSet<Otobus> Otobusler { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Araba>().HasData(
                    new Araba
                    {
                        Id = 1,
                        Marka = "Toyota",
                        Fiyat = 50000,
                        IkinciElMi = false
                    },
                    new Araba
                    {
                        Id = 2,
                        Marka = "Ford",
                        Fiyat = 45000,
                        IkinciElMi = true
                    },
                    new Araba
                    {
                        Id = 3,
                        Marka = "Honda",
                        Fiyat = 60000,
                        IkinciElMi = false
                    });
        }

    }
}
