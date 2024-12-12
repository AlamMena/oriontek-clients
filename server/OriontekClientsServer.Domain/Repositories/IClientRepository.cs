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
        Task<IEnumerable<Client>> GetClientsByNameAsync(string name, int page, int limit);
        Task<Client?> GetClientByIdentificationAsync(string identification);
        Task<int> CountClientsByNameAsync(string name);
        Task<int> DeleteClientAddresses(int clientId, IEnumerable<ClientAddress> addresses);
        Task<int> UpdateClientAddresses(int clientId, IEnumerable<ClientAddress> addresses);
        Task<int> AddClientAddresses(int clientId, IEnumerable<ClientAddress> addresses);

    }
}
