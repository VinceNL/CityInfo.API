namespace CityInfo.API.Models
{
    /// <summary>
    /// A DTO for a point of interest
    /// </summary>
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}