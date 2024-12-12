using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Features.Clients.Requests
{
    public class GetAllClientsCommand : IRequest<ClientsPaginatedDto>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
