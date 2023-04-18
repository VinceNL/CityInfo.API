using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options) { }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointOfInterest { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
                new City("Amsterdam")
                {
                    Id = 1,
                    Description = "The one with the windows",
                },
                new City("Nijmegen")
                {
                    Id = 2,
                    Description = "Home sweet home",
                },
                new City("Arnhem")
                {
                    Id = 3,
                    Description = "Why do I feel uncomfortable?",
                });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Vondelpark")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "Hoe ruikt het vannacht?",
                },
                new PointOfInterest("Kronenburger park")
                {
                    Id = 2,
                    CityId = 2,
                    Description = "Ga die wereld uit!",
                },
                new PointOfInterest("Burgers Zoo")
                {
                    Id = 3,
                    CityId = 3,
                    Description = "Dierentuin",
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}