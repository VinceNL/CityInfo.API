using CityInfo.API.Models;

namespace CityInfo.API
{
    /// <summary>
    /// Deprecated in-memory test data
    /// </summary>
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            // init dummy data
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Amsterdam",
                    Description = "The one with the windows",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Vondelpark",
                            Description = "Stads park"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "De Dam",
                            Description = "Hart van de stad"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Nijmegen",
                    Description = "Home sweet home",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Kronenburger park",
                            Description = "Stads park"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Waalkade",
                            Description = "Stad aan de Waal"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Arnhem",
                    Description = "Why do I feel uncomfortable?",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Burgers Zoo",
                            Description = "Dierentuin"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Kranenburg",
                            Description = "Stads wijk"
                        }
                    }
                }
            };
        }
    }
}