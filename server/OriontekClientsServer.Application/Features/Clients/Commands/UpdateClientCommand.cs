using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Features.Clients.Commands
{
    public class UpdateClientCommand : IRequest<ClientWithAddressesDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public IEnumerable<ClientAddressDto> Addresses { get; set; } = [];
    }
}
