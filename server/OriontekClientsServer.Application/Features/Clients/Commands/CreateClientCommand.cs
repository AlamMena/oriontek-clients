using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;


namespace OriontekClientsServer.Application.Features.Clients.Requests
{
    public class CreateClientCommand : IRequest<ClientDto>
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
