using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CityInfo.API.Controllers
{
    /// <summary>
    /// Provides an API endpoint for authentication and authorization token generation.
    /// </summary>
    [ApiController]
    [Route("api/authentication")]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the AuthenticationController with the specified IConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration to access app settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the IConfiguration is null.</exception>
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Represents the request body for authentication.
        /// </summary>
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        /// <summary>
        /// Represents a user with their authorization claim data.
        /// </summary>
        public class CityInfoUser
        {
            public CityInfoUser(
                int userId,
                string userName,
                string firstName,
                string lastName,
                string city)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                City = city;
            }

            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
        }

        /// <summary>
        /// Generates a Bearer authentication token for the specified user credentials.
        /// </summary>
        /// <param name="request">The request containing the user credentials.</param>
        /// <returns>A Bearer token string if the credentials are valid; otherwise, an Unauthorized response.</returns>
        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<string> Authenticate(
            AuthenticationRequestBody request)
        {
            var user = ValidateUserCredentials(
                request.UserName,
                request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.UserId.ToString()),
                new Claim("given_name", user.FirstName),
                new Claim("family_name", user.LastName),
                new Claim("city", user.City)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        /// <summary>
        /// Validates the user credentials and returns a CityInfoUser object if they are valid.
        /// </summary>
        /// <param name="userName">The user name to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>A CityInfoUser object if the credentials are valid; otherwise, null.</returns>
        private CityInfoUser ValidateUserCredentials(string? userName, string? password)
        {
            // For demo purposes, we do not validate against a database and assume valid credentials

            return new CityInfoUser(
                1,
                userName ?? "",
                "Vincent",
                "Camp",
                "Nijmegen");
        }
    }
}