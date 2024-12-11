using OriontekClientsServer.Domain.Entities;
using OriontekClientsServer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client?> GetClientByIdWithAddressesAsync(int id);
        Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
    }
}
