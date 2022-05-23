﻿using CommandCenter.API.Controllers.Base;
using CommandCenter.BLL.Services.CQRS.Framework.Queries;
using CommandCenter.Core.Resources;
using CommandCenter.Core.Resources.Base;
using MediatR;
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
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor of FrameworkController
        /// </summary>
        /// <param name="mediator"></param>
        public FrameworkController(IMediator mediator)
        {
            _mediator = mediator;
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
            var models = await _mediator.Send(new GetFrameworksQuery());
            return Ok(models);
        }
    }
}
