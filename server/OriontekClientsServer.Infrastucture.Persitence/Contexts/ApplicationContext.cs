using Microsoft.EntityFrameworkCore;
using OriontekClientsServer.Domain.Entities;
using OriontekClientsServer.Infrastucture.Persitence.EntitiesConfig.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Infrastucture.Persitence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsConfig());
            modelBuilder.ApplyConfiguration(new ClientAddressConfig());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientsAddresses { get; set; }
    }
}
