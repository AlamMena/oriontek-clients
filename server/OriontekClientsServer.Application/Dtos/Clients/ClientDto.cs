﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Dtos.Clients
{
    public class ClientDto
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
