using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Features.Clients.Requests
{
    public record GetClientByIdCommand : IRequest<ClientDto>
    {
        public int Id { get; set; }
    }
}
