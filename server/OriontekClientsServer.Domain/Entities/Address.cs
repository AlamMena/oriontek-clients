using OriontekClientsServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Domain.Entities
{
    public class Address : CoreEntity
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public Client Client { get; set; } = null!;
    }
}
