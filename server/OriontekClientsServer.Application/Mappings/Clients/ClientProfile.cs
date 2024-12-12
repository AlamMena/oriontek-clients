using AutoMapper;
using OriontekClientsServer.Application.Dtos.Clients;
using OriontekClientsServer.Application.Features.Clients.Commands;
using OriontekClientsServer.Application.Features.Clients.Requests;
using OriontekClientsServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Mappings.Clients
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, ClientWithAddressesDto>().ReverseMap();
            CreateMap<ClientAddress, ClientAddressDto>().ReverseMap();
            CreateMap<CreateClientCommand, Client>();
            CreateMap<UpdateClientCommand, Client>();
        }
    }
}
