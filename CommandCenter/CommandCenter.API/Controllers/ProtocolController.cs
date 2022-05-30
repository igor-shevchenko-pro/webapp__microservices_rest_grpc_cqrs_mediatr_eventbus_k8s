using CommandCenter.API.Controllers.Base;
using CommandCenter.BLL.CQRS.Commands.Base;
using CommandCenter.BLL.CQRS.Queries.Base;
using CommandCenter.Core.Resources;
using CommandCenter.Core.Resources.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandCenter.API.Controllers
{
    /// <summary>
    /// Controller used for handling "<see cref="T:Protocol"/>" resources
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ProtocolController : BaseApiController
    {
        /// <summary>
        /// Create a new "<see cref="T:Protocol"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Resource" from the body
        /// 
        ///    POST /api/protocol
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "description": "string",
        ///        "type": "Web",
        ///    }
        /// 
        /// </remarks>
        /// <param name="resource">The "<see cref="T:Protocol"/>" resource to create</param>
        /// <response code="201">The new resource was created successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] ProtocolCreateResource resource)
        {
            var id = await Mediator.Send(new BaseCreateCommand<ProtocolCreateResource>(resource));
            return CreatedAtAction(nameof(GetAsync), new { Id = id }, resource);
        }

        /// <summary>
        /// Update an existing "<see cref="T:Protocol"/>" resource
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameters "Id" from the URL and "Resource" from the body
        /// 
        ///    PUT /api/protocol/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///    {
        ///        "operationalStateStatus": "Active",
        ///        "name": "string",
        ///        "description": "string",
        ///        "type": "Web",
        ///    }
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Protocol"/>" resource to update</param>
        /// <param name="resource">The "<see cref="T:Protocol"/>" resource to update</param>
        /// <response code="204">The requested resource was updated successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="404">Requested resource is not found</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] ProtocolCreateResource resource)
        {
            await Mediator.Send(new BaseUpdateCommand<ProtocolCreateResource>(id, resource));
            return NoContent();
        }

        /// <summary>
        /// Delete the "<see cref="T:Protocol"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     DELETE /api/protocol/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// 
        /// </remarks>
        /// <param name="id">The Id of the "<see cref="T:Protocol"/>" resource to delete</param>
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
            await Mediator.Send(new BaseRemoveCommand<ProtocolBaseResource>(id));
            return NoContent();
        }

        /// <summary>
        /// Retrieve the "<see cref="T:Protocol"/>" resource by Id
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called with parameter "Id" from the URL
        /// 
        ///     GET /api/protocol/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        ///   
        /// </remarks>
        /// <param name="id">The Id of the requested "<see cref="T:Protocol"/>" resource to get</param>
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
            var model = await Mediator.Send(new BaseGetByIdQuery<ProtocolGetResource>(id));
            return Ok(model);
        }

        /// <summary>
        /// Get a list with all available "<see cref="T:Protocol"/>" resources
        /// </summary>
        /// <remarks>
        /// Sample of request:
        /// The API request should be called without parameters
        /// 
        ///     GET /api/protocol
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
            var models = await Mediator.Send(new BaseGetAllQuery<ProtocolGetResource>());
            return Ok(models);
        }
    }
}
