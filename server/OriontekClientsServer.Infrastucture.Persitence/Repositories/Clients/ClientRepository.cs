using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OriontekClientsServer.Domain.Entities;
using OriontekClientsServer.Domain.Exceptions;
using OriontekClientsServer.Domain.Interfaces;
using OriontekClientsServer.Domain.Repositories;
using OriontekClientsServer.Infrastucture.Persitence.Contexts;
using OriontekClientsServer.Infrastucture.Persitence.Repositories.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static OriontekClientsServer.Infrastucture.Persitence.Repositories.Clients.ClientRepository;

namespace OriontekClientsServer.Infrastucture.Persitence.Repositories.Clients
{
    internal class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ApplicationContext _dbContext;

        public ClientRepository(ApplicationContext dbContext, IConfiguration configuration) : base(dbContext,
            configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<Client?> GetClientByIdWithAddressesAsync(int id)
        {
            try
            {
                var client = await _dbContext.Clients.Include(d => d.Addresses).FirstOrDefaultAsync(d => d.Id == id);

                return client;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
