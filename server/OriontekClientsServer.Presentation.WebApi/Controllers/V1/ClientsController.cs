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

            var client = await Mediator.Send(command);
            return Created($"/client/{client.Id}", client);


        }

        [HttpGet("clients")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllClientsCommand command)
        {

            var clients = await Mediator.Send(command);
            return Ok(clients);


        }

        [HttpGet("client/{Id}")]
        public async Task<IActionResult> GetByIdAsync(GetClientByIdCommand command)
        {
            var client = await Mediator.Send(command);
            return Ok(client);

        }

        [HttpGet("clients/name")]
        public async Task<IActionResult> GetClientsByNameAsync([FromQuery] GetClientsByNameCommand command)
        {
            var client = await Mediator.Send(command);
            return Ok(client);
        }
        [HttpPatch("client")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateClientCommand command)
        {

            var client = await Mediator.Send(command);
            return Ok(client);

        }
        [HttpDelete("client/{Id}")]
        public async Task<IActionResult> DeleteAsync(DeleteClientCommand command)
        {
            await Mediator.Send(command);
            return Ok();

        }
    }
}
