using Microsoft.AspNetCore.Mvc;

namespace DistributionCenter.API.Controllers.Base
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        // Define here any common logic

        protected virtual string GetUserId() => string.Empty;
        protected virtual string GetLanguageId() => string.Empty;
    }
}
