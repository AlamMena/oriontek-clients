
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OriontekClientsServer.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
