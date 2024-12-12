using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OriontekClientsServer.Application.Features.Clients.Commands;
using OriontekClientsServer.Application.Features.Clients.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace OriontekClientsServer.Presentation.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Client controller management")]
    [Route("api")]
    public class ClientsController : BaseApiController
    {
        public ClientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("client")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateClientCommand command)
        {
            try
            {
                var client = await Mediator.Send(command);
                return Created($"/client/{client.Id}", client);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }

        }

        [HttpGet("clients")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllClientsCommand command)
        {
            try
            {
                var clients = await Mediator.Send(command);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }

        }

        [HttpGet("client/{Id}")]
        public async Task<IActionResult> GetByIdAsync(GetClientByIdCommand command)
        {
            try
            {
                var client = await Mediator.Send(command);
                return Ok(client);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }

        }
        [HttpPatch("client")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateClientCommand command)
        {
            try
            {
                var client = await Mediator.Send(command);

                return Ok(client);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }

        }
        [HttpDelete("client/{Id}")]
        public async Task<IActionResult> DeleteAsync(DeleteClientCommand command)
        {
            try
            {
                await Mediator.Send(command);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }

        }
    }
}
