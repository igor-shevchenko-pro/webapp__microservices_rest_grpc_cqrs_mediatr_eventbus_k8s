using DistributionCenter.API.Controllers.Base;
using DistributionCenter.API.Resources;
using DistributionCenter.Core.Interfaces.Services;
using DistributionCenter.Core.Resources.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionCenter.API.Controllers
{
    /// <summary>
    /// Controller used for handling "<see cref="T:Server"/>" resources
    /// </summary>
    [ApiController]
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    public class ServerController : BaseApiController
    {
        private readonly IServerService _serverService;

        /// <summary>
        /// Constructor of ServerController
        /// </summary>
        /// <param name="serverService"></param>
        public ServerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        /// <summary>
        /// Create a new "<see cref="T:Server"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Resource" from the body
        /// 
        ///    POST /api/server
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "type": "Proxy"
        ///    }
        /// 
        /// </remarks>
        /// <param name="resource">The "<see cref="T:Server"/>" resource to create</param>
        /// <response code="201">The new resource was created successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] ServerCreateResource resource)
        {
            var id = await _serverService.CreateAsync(resource);
            return CreatedAtAction(nameof(GetAsync), new { Id = id }, resource);
        }

        /// <summary>
        /// Update an existing "<see cref="T:Server"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameters "Id" from the URL and "Resource" from the body
        /// 
        ///    PUT /api/server/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "type": "Proxy"
        ///    }
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Server"/>" resource to update</param>
        /// <param name="resource">The "<see cref="T:Server"/>" resource to update</param>
        /// <response code="204">The requested resource was updated successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] ServerCreateResource resource)
        {
            await _serverService.UpdateAsync(id, resource);
            return NoContent();
        }

        /// <summary>
        /// Delete the "<see cref="T:Server"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     DELETE /api/server/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Server"/>" resource to delete</param>
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
            await _serverService.RemoveAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Retrieve the "<see cref="T:Server"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     GET /api/server/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///   
        /// </remarks>
        /// <param name="id">The Id of the requested "<see cref="T:Server"/>" resource to get</param>
        /// <response code="200">Return the requested resource</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServerGetResource), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(string id)
        {
            var model = await _serverService.GetAsync(id);
            return Ok(model);
        }

        /// <summary>
        /// Get a list with all available "<see cref="T:Server"/>" resources
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called without parameters
        /// 
        ///     GET /api/server
        ///     
        /// </remarks>
        /// <response code="200">Returns a list with the available resources</response>
        /// <response code="400">The request could not be understood by the server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServerGetResource>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _serverService.GetAllAsync();
            return Ok(models);
        }
    }
}
