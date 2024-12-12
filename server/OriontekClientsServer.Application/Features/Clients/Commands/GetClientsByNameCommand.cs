using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Features.Clients.Commands
{
    public class GetClientsByNameCommand : IRequest<ClientsPaginatedDto>
    {
        public string Name { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}
