using DistributionCenter.API.Controllers.Base;
using DistributionCenter.Core.Interfaces.Services;
using DistributionCenter.Core.Resources;
using DistributionCenter.Core.Resources.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionCenter.API.Controllers
{
    /// <summary>
    /// Controller used for handling "<see cref="T:Framework"/>" resources
    /// </summary>
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [Route("api/[controller]")]
    public class FrameworkController : BaseApiController
    {
        private readonly IFrameworkService _frameworkService;

        /// <summary>
        /// Constructor of FrameworkController
        /// </summary>
        /// <param name="frameworkService"></param>
        public FrameworkController(IFrameworkService frameworkService)
        {
            _frameworkService = frameworkService;
        }

        /// <summary>
        /// Create a new "<see cref="T:Framework"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Resource" from the body
        /// 
        ///    POST /api/framework
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "version": "string",
        ///        "releaseDate": "dateTime"
        ///    }
        /// 
        /// </remarks>
        /// <param name="resource">The "<see cref="T:Framework"/>" resource to create</param>
        /// <response code="201">The new resource was created successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] FrameworkCreateResource resource)
        {
            var id = await _frameworkService.CreateAsync(resource);
            return CreatedAtAction(nameof(GetAsync), new { Id = id }, resource);
        }

        /// <summary>
        /// Update an existing "<see cref="T:Framework"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameters "Id" from the URL and "Resource" from the body
        /// 
        ///    PUT /api/framework/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "version": "string",
        ///        "releaseDate": "dateTime"
        ///    }
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Framework"/>" resource to update</param>
        /// <param name="resource">The "<see cref="T:Framework"/>" resource to update</param>
        /// <response code="204">The requested resource was updated successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] FrameworkCreateResource resource)
        {
            await _frameworkService.UpdateAsync(id, resource);
            return NoContent();
        }

        /// <summary>
        /// Delete the "<see cref="T:Framework"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     DELETE /api/framework/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Framework"/>" resource to delete</param>
        /// <response code="204">The requested resource was removed successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            await _frameworkService.RemoveAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Retrieve the "<see cref="T:Framework"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     GET /api/framework/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///   
        /// </remarks>
        /// <param name="id">The Id of the requested "<see cref="T:Framework"/>" resource to get</param>
        /// <response code="200">Return the requested resource</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FrameworkGetResource), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(string id)
        {
            var model = await _frameworkService.GetAsync(id);
            return Ok(model);
        }

        /// <summary>
        /// Get a list with all available "<see cref="T:Framework"/>" resources
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called without parameters
        /// 
        ///     GET /api/framework
        ///     
        /// </remarks>
        /// <response code="200">Returns a list with the available resources</response>
        /// <response code="400">The request could not be understood by the server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FrameworkGetResource>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _frameworkService.GetAllAsync();
            return Ok(models);
        }
    }
}
