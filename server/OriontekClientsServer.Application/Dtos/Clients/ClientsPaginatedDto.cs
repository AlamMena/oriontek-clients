using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Dtos.Clients
{
    public class ClientsPaginatedDto
    {
        public int DataCount { get; set; }
        public IEnumerable<ClientDto> Clients { get; set; } = [];
    }
}
