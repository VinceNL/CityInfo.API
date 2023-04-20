using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    /// <summary>
    /// Handles API endpoints related to testing file operations, such as retrieving files.
    /// </summary>
    [ApiController]
    [Route("api/files")]
    [Authorize]
    [Produces("application/json")]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        /// <summary>
        /// Initialize a new instance of FilesController with the required services
        /// </summary>
        /// <param name="fileExtensionContentTypeProvider"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public FilesController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(
                    nameof(fileExtensionContentTypeProvider));
        }

        /// <summary>
        /// Retrieves a test file based on the provided fileId.
        /// </summary>
        /// <param name="fileId">The ID of the file to retrieve</param>
        /// <returns>The requested file as an ActionResult</returns>
        [HttpGet("{fileId}")]
        [ProducesResponseType(StatusCodes.Status206PartialContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status416RangeNotSatisfiable)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetFile(string fileId)
        {
            // Look up the actual file, depending on fileId
            var pathToFile = "azure-fundamentals.png";

            // check wether the file exists
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
