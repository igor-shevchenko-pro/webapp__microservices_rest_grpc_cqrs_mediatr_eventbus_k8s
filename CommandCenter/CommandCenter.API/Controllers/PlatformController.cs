using CommandCenter.API.Controllers.Base;
using CommandCenter.Core.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandCenter.API.Controllers
{
    /// <summary>
    /// Controller used for handling "<see cref="T:Platform"/>" resources
    /// </summary>
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [Route("api/[controller]")]
    public class PlatformController : BaseApiController
    {
        public PlatformController()
        {

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
        ///        "publisher": "string",
        ///        "cost": "string"
        ///    }
        /// 
        /// </remarks>
        /// <param name="resource">The "<see cref="T:Platform"/>" resource to create</param>
        /// <response code="201">The new resource was created successfully</response>
        /// <response code="400">The request could not be understood by server</response>
        /// <response code="500">An internal server error occurred</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorDetailsResource), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] PlatformCreateResource resource)
        {
            //var id = await _platformService.CreateAsync(resource);
            //return CreatedAtAction(nameof(GetAsync), new { Id = id }, resource);
            return Ok();
        }
    }
}
