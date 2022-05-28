using CommandCenter.API.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
