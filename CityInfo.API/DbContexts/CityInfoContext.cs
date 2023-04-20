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
               new City("Paris")
               {
                   Id = 1,
                   Description = "City of Love",
               },
               new City("New York City")
               {
                   Id = 2,
                   Description = "Big Apple",
               },
               new City("Tokyo")
               {
                   Id = 3,
                   Description = "Pearl of the east",
               },
               new City("London")
               {
                   Id = 4,
                   Description = "Northern (not)Europe",
               },
               new City("Rome")
               {
                   Id = 5,
                   Description = "The ancient city",
               },
               new City("Sydney")
               {
                   Id = 6,
                   Description = "The lone city down under",
               },
               new City("Rio de Janeiro")
               {
                   Id = 7,
                   Description = "The galamour city of Southern-America",
               },
               new City("Dubai")
               {
                   Id = 8,
                   Description = "THe city of money",
               });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Eiffel Tower")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "landmark",
                },
                new PointOfInterest("Louvre Museum")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "art museum",
                },
                new PointOfInterest("Notre-Dame de Paris")
                {
                    Id = 3,
                    CityId = 1,
                    Description = "cathedral",
                },
                new PointOfInterest("Statue of Liberty")
                {
                    Id = 4,
                    CityId = 2,
                    Description = "landmark",
                },
                new PointOfInterest("Central Park")
                {
                    Id = 5,
                    CityId = 2,
                    Description = "park",
                },
                new PointOfInterest("Empire State Building")
                {
                    Id = 6,
                    CityId = 2,
                    Description = "skyscraper",
                },
                new PointOfInterest("Tokyo Tower")
                {
                    Id = 7,
                    CityId = 3,
                    Description = "landmark",
                },
                new PointOfInterest("Tokyo Disneyland")
                {
                    Id = 8,
                    CityId = 3,
                    Description = "amusement park",
                },
                new PointOfInterest("Senso-ji Temple")
                {
                    Id = 9,
                    CityId = 3,
                    Description = "temple",
                },
                new PointOfInterest("Big Ben")
                {
                    Id = 10,
                    CityId = 4,
                    Description = "landmark",
                },
                new PointOfInterest("British Museum")
                {
                    Id = 11,
                    CityId = 4,
                    Description = "museum",
                },
                new PointOfInterest("Tower Bridge")
                {
                    Id = 12,
                    CityId = 4,
                    Description = "bridge",
                },
                new PointOfInterest("Colosseum")
                {
                    Id = 13,
                    CityId = 5,
                    Description = "amphitheater",
                },
                new PointOfInterest("Pantheon")
                {
                    Id = 14,
                    CityId = 5,
                    Description = "temple",
                },
                new PointOfInterest("Trevi Fountain")
                {
                    Id = 15,
                    CityId = 5,
                    Description = "fountain",
                },
                new PointOfInterest("Sydney Opera House")
                {
                    Id = 16,
                    CityId = 6,
                    Description = "performing arts theater",
                },
                new PointOfInterest("Sydney Harbour Bridge")
                {
                    Id = 17,
                    CityId = 6,
                    Description = "bridge",
                },
                new PointOfInterest("Bondi Beach")
                {
                    Id = 18,
                    CityId = 6,
                    Description = "beach",
                },
                new PointOfInterest("Christ the Redeemer")
                {
                    Id = 19,
                    CityId = 7,
                    Description = "statue",
                },
                new PointOfInterest("Sugarloaf Mountain")
                {
                    Id = 20,
                    CityId = 7,
                    Description = "mountain",
                },
                new PointOfInterest("Copacabana Beach")
                {
                    Id = 21,
                    CityId = 7,
                    Description = "beach",
                },
                new PointOfInterest("Burj Khalifa")
                {
                    Id = 22,
                    CityId = 8,
                    Description = "skyscraper",
                },
                new PointOfInterest("Dubai Mall")
                {
                    Id = 23,
                    CityId = 8,
                    Description = "shopping mall",
                },
                new PointOfInterest("Palm Jumeirah")
                {
                    Id = 24,
                    CityId = 8,
                    Description = "artificial island",
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}