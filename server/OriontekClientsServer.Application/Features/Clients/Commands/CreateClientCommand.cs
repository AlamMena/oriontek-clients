using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;


namespace OriontekClientsServer.Application.Features.Clients.Requests
{
    public class CreateClientCommand : IRequest<ClientWithAddressesDto>
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public IEnumerable<ClientAddressDto> Addresses { get; set; } = [];
    }
}
