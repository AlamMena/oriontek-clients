using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OriontekClientsServer.Domain.Entities;

namespace OriontekClientsServer.Infrastucture.Persitence.EntitiesConfig.Clients
{
    internal class ClientsConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(60);
            builder.Property(x => x.LastName).HasMaxLength(60);
            builder.Property(x => x.Identification).HasMaxLength(30);

            builder.HasMany(d => d.Addresses).WithOne(d => d.Client).OnDelete(DeleteBehavior.Restrict);

            builder.Navigation(d => d.Addresses).AutoInclude();
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
