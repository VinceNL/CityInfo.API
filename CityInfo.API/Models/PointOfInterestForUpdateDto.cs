using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    /// <summary>
    /// A DTO for a updating an existing point of interest
    /// </summary>
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "A valid name value should be provided")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
