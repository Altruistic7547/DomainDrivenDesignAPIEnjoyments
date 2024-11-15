using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PolyForge.AspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        public IMediator? _mediatorInstance;

        protected IMediator _mediator
        {
            get
            {
                return _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
