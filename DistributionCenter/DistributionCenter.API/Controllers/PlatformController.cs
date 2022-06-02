using DistributionCenter.API.Controllers.Base;
using DistributionCenter.Core.Interfaces.Services;
using DistributionCenter.Core.Resources;
using DistributionCenter.Core.Resources.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DistributionCenter.API.Controllers
{
    /// <summary>
    /// Controller used for handling "<see cref="T:Platform"/>" resources
    /// </summary>
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    [Route("api/[controller]")]
    public class PlatformController : BaseApiController
    {
        private readonly IPlatformService _platformService;

        /// <summary>
        /// Constructor of PlatformController
        /// </summary>
        /// <param name="platformService"></param>
        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        /// <summary>
        /// Create a new "<see cref="T:Platform"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Resource" from the body
        /// 
        ///    POST /api/platform
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "version": "string",
        ///        "fileSize": "double"
        ///    }
        /// 
        /// </remarks>
        /// <param name="resource">The "<see cref="T:Platform"/>" resource to create</param>
        /// <response code="201">The new resource was created successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] PlatformCreateResource resource)
        {
            var id = await _platformService.CreateAsync(resource);
            return CreatedAtAction(nameof(GetAsync), new { Id = id }, resource);
        }

        /// <summary>
        /// Update an existing "<see cref="T:Platform"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameters "Id" from the URL and "Resource" from the body
        /// 
        ///    PUT /api/platform/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "version": "string",
        ///        "fileSize": "double"
        ///    }
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Platform"/>" resource to update</param>
        /// <param name="resource">The "<see cref="T:Platform"/>" resource to update</param>
        /// <response code="204">The requested resource was updated successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] PlatformCreateResource resource)
        {
            await _platformService.UpdateAsync(id, resource);
            return NoContent();
        }

        /// <summary>
        /// Delete the "<see cref="T:Platform"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     DELETE /api/platform/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Platform"/>" resource to delete</param>
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
            await _platformService.RemoveAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Retrieve the "<see cref="T:Platform"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     GET /api/platform/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///   
        /// </remarks>
        /// <param name="id">The Id of the requested "<see cref="T:Platform"/>" resource to get</param>
        /// <response code="200">Return the requested resource</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlatformGetResource), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(string id)
        {
            var model = await _platformService.GetAsync(id);
            return Ok(model);
        }

        /// <summary>
        /// Get a list with all available "<see cref="T:Platform"/>" resources
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called without parameters
        /// 
        ///     GET /api/platform
        ///     
        /// </remarks>
        /// <response code="200">Returns a list with the available resources</response>
        /// <response code="400">The request could not be understood by the server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlatformGetResource>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _platformService.GetAllAsync();
            return Ok(models);
        }




        /// <summary>
        /// Test demonstration of calling the get method apiVersion 1.1
        /// </summary>
        [HttpGet("get_v1_1")]
        [MapToApiVersion("1.1")]
        [Produces(MediaTypeNames.Application.Json)]
        public string GetV1_1Async() => $"Response from action: {nameof(GetV1_1Async)}";

        /// <summary>
        /// Test demonstration of calling the get method apiVersion 1.2
        /// </summary>
        [HttpGet("get_v1_2")]
        [MapToApiVersion("1.2")]
        [Produces(MediaTypeNames.Application.Json)]
        public string GetV1_2Async() => $"Response from action: {nameof(GetV1_2Async)}";
    }
}
