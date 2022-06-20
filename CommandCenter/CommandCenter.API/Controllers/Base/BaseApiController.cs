using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;

namespace CommandCenter.API.Controllers.Base
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator = default!;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        protected virtual string GetUserId()
        {
            return this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        protected virtual string GetLanguageId() => string.Empty;
    }
}