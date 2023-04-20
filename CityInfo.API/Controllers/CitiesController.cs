using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CityInfo.API.Controllers
{
    /// <summary>
    /// Handles city-related operations and associated points of interest.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/cities")]
    [Authorize]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        private const int maxCitiesPageSize = 20;

        /// <summary>
        /// Initializes a new instance of the CitiesController with the specified ICityInfoRepository and IMapper.
        /// </summary>
        /// <param name="cityInfoRepository">The repository for city data access.</param>
        /// <param name="mapper">The mapper for object-to-object mapping.</param>
        /// <exception cref="ArgumentNullException">Thrown when either ICityInfoRepository or IMapper is null.</exception>ception>
        public CitiesController(
            ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Retrieves a collection of cities with their points of interest based on search criteria.
        /// </summary>
        /// <param name="name">Optional name filter for cities.</param>
        /// <param name="searchQuery">Optional search query for city descriptions.</param>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page for pagination.</param>
        /// <returns>A list of CityDto objects.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities(
            string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }

            var (cityEntities, paginationMetadata) = await _cityInfoRepository
                .GetCitiesAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CityDto>>(cityEntities));
        }

        /// <summary>
        /// Retrieves a city by its ID.
        /// </summary>
        /// <param name="id">The ID of the city to retrieve.</param>
        /// <param name="includePointsOfInterest">Whether or not to include the city's points of interest.</param>
        /// <returns>An IActionResult containing the requested city data.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCity(
            int id,
            bool includePointsOfInterest = false)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}