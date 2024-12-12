using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Features.Clients.Requests
{
    public record GetClientByIdCommand : IRequest<ClientWithAddressesDto>
    {
        public int Id { get; set; }
    }
}
