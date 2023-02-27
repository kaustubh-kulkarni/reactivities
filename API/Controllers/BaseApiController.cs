using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController: ControllerBase
    {
        private IMediator _mediator;

        //If mediator is present then we set it or else we get the service and then set it
        protected IMediator Mediator => _mediator ??=
             HttpContext.RequestServices.GetService<IMediator>();
    }
}