using CommandCenter.API.Controllers.Base;
using CommandCenter.BLL.CQRS.FrameworkQueries;
using CommandCenter.Core.Resources;
using CommandCenter.Core.Resources.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandCenter.API.Controllers
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
            var model = await Mediator.Send(new GetByIdFrameworkQuery(id));
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
            var models = await Mediator.Send(new GetAllFrameworksQuery());
            return Ok(models);
        }
    }
}
