using CommandCenter.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

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
    }
}
