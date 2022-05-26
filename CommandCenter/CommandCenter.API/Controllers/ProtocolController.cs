using CommandCenter.API.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommandCenter.API.Controllers
{
    /// <summary>
    /// Controller used for handling "<see cref="T:Protocol"/>" resources
    /// </summary>
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [Route("api/[controller]")]
    public class ProtocolController : BaseApiController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor of ProtocolController
        /// </summary>
        /// <param name="mediator"></param>
        public ProtocolController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
