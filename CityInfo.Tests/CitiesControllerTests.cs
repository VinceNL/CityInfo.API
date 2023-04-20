using AutoMapper;
using CityInfo.API.Controllers;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CityInfo.Tests
{
    public class CitiesControllerTests
    {
        private readonly Mock<ICityInfoRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CitiesController _controller;

        public CitiesControllerTests()
        {
            _mockRepository = new Mock<ICityInfoRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CitiesController(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async void GetCities_ReturnsOkResult()
        {
            // Arrange
            var testCities = _mockRepository.Setup(repo => repo.GetCitiesAsync()).Returns(GetTestCities);

            // Act
            var result = await _controller.GetCities(null, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var cities = Assert.IsAssignableFrom<IEnumerable<CityWithoutPointsOfInterestDto>>(okResult.Value);
            Assert.Equal(2, cities.Count());
        }

        private List<CityWithoutPointsOfInterestDto> GetTestCities()
        {
            return new List<CityWithoutPointsOfInterestDto>
            {
                new CityWithoutPointsOfInterestDto { Id = 1, Name = "City1", Description = "City1 Description" },
                new CityWithoutPointsOfInterestDto { Id = 2, Name = "City2", Description = "City2 a Description" }
            };
        }
    }
}