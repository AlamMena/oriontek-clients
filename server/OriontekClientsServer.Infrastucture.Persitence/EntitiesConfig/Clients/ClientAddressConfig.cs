using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OriontekClientsServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Infrastucture.Persitence.EntitiesConfig.Clients
{
    internal class ClientAddressConfig : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Street).HasMaxLength(60);

            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
