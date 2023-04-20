﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20230420202315_NewDataMigration")]
    partial class NewDataMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "City of Love",
                            Name = "Paris"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Big Apple",
                            Name = "New York City"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Pearl of the east",
                            Name = "Tokyo"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Northern (not)Europe",
                            Name = "London"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The ancient city",
                            Name = "Rome"
                        },
                        new
                        {
                            Id = 6,
                            Description = "The lone city down under",
                            Name = "Sydney"
                        },
                        new
                        {
                            Id = 7,
                            Description = "The galamour city of Southern-America",
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 8,
                            Description = "THe city of money",
                            Name = "Dubai"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "landmark",
                            Name = "Eiffel Tower"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "art museum",
                            Name = "Louvre Museum"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Description = "cathedral",
                            Name = "Notre-Dame de Paris"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Description = "landmark",
                            Name = "Statue of Liberty"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 2,
                            Description = "park",
                            Name = "Central Park"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 2,
                            Description = "skyscraper",
                            Name = "Empire State Building"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 3,
                            Description = "landmark",
                            Name = "Tokyo Tower"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 3,
                            Description = "amusement park",
                            Name = "Tokyo Disneyland"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 3,
                            Description = "temple",
                            Name = "Senso-ji Temple"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 4,
                            Description = "landmark",
                            Name = "Big Ben"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 4,
                            Description = "museum",
                            Name = "British Museum"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 4,
                            Description = "bridge",
                            Name = "Tower Bridge"
                        },
                        new
                        {
                            Id = 13,
                            CityId = 5,
                            Description = "amphitheater",
                            Name = "Colosseum"
                        },
                        new
                        {
                            Id = 14,
                            CityId = 5,
                            Description = "temple",
                            Name = "Pantheon"
                        },
                        new
                        {
                            Id = 15,
                            CityId = 5,
                            Description = "fountain",
                            Name = "Trevi Fountain"
                        },
                        new
                        {
                            Id = 16,
                            CityId = 6,
                            Description = "performing arts theater",
                            Name = "Sydney Opera House"
                        },
                        new
                        {
                            Id = 17,
                            CityId = 6,
                            Description = "bridge",
                            Name = "Sydney Harbour Bridge"
                        },
                        new
                        {
                            Id = 18,
                            CityId = 6,
                            Description = "beach",
                            Name = "Bondi Beach"
                        },
                        new
                        {
                            Id = 19,
                            CityId = 7,
                            Description = "statue",
                            Name = "Christ the Redeemer"
                        },
                        new
                        {
                            Id = 20,
                            CityId = 7,
                            Description = "mountain",
                            Name = "Sugarloaf Mountain"
                        },
                        new
                        {
                            Id = 21,
                            CityId = 7,
                            Description = "beach",
                            Name = "Copacabana Beach"
                        },
                        new
                        {
                            Id = 22,
                            CityId = 8,
                            Description = "skyscraper",
                            Name = "Burj Khalifa"
                        },
                        new
                        {
                            Id = 23,
                            CityId = 8,
                            Description = "shopping mall",
                            Name = "Dubai Mall"
                        },
                        new
                        {
                            Id = 24,
                            CityId = 8,
                            Description = "artificial island",
                            Name = "Palm Jumeirah"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Navigation("PointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}