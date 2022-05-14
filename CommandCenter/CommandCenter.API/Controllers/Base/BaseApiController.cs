using Microsoft.AspNetCore.Mvc;

namespace CommandCenter.API.Controllers.Base
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        // Define here any common logic

        protected virtual string GetUserId() => string.Empty;

        protected virtual string GetLanguageId() => string.Empty;
    }
}