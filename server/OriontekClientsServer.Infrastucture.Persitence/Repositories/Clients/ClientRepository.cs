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


namespace OriontekClientsServer.Infrastucture.Persitence.Repositories.Clients
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ApplicationContext _dbContext;

        public ClientRepository(ApplicationContext dbContext) : base(dbContext)
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

        public async Task<Client?> GetClientByIdentificationAsync(string identification)
        {
            try
            {
                var client = await _dbContext.Clients.FirstOrDefaultAsync(d => d.Identification == identification);

                return client;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<int> AddClientAddresses(int clientId, IEnumerable<ClientAddress> addresses)
        {
            try
            {
                var client = await _dbContext.Clients.FindAsync(clientId);

                if (client != null)
                {
                    foreach (var item in addresses)
                    {
                        item.Client = client;
                    }
                    await _dbContext.ClientsAddresses.AddRangeAsync(addresses);
                }

                return await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<int> DeleteClientAddresses(int clientId, IEnumerable<ClientAddress> addresses)
        {
            try
            {
                var dbAddresses = await _dbContext.ClientsAddresses.Include(d => d.Client).Where(d => d.Client.Id == clientId).ToListAsync();
                foreach (var address in addresses)
                {
                    var dbAddress = dbAddresses.FirstOrDefault(d => d.Id == address.Id);

                    if (dbAddress != null)
                    {
                        dbAddress.IsDeleted = true;
                        dbAddress.UpdatedAt = DateTime.UtcNow;

                    }
                }

                return await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<int> UpdateClientAddresses(int clientId, IEnumerable<ClientAddress> addresses)
        {
            try
            {
                var dbAddresses = await _dbContext.ClientsAddresses.Include(d => d.Client).Where(d => d.Client.Id == clientId).ToListAsync();
                foreach (var address in addresses)
                {
                    var dbAddress = dbAddresses.FirstOrDefault(d => d.Id == address.Id);

                    if (dbAddress != null)
                    {
                        dbAddress.IsDeleted = false;
                        dbAddress.UpdatedAt = DateTime.UtcNow;

                        _dbContext.Entry(dbAddress).CurrentValues.SetValues(address);
                    }
                }

                return await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
