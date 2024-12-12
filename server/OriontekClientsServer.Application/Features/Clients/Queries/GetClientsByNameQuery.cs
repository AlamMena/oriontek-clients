using AutoMapper;
using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using OriontekClientsServer.Application.Features.Clients.Commands;
using OriontekClientsServer.Application.Features.Clients.Requests;
using OriontekClientsServer.Domain.Exceptions;
using OriontekClientsServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Features.Clients.Queries
{
    public class GetClientsByNameQueryHandler : IRequestHandler<GetClientsByNameCommand, ClientsPaginatedDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsByNameQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientsPaginatedDto> Handle(GetClientsByNameCommand request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetClientsByNameAsync(request.Name, request.Page, request.Limit);

            return new ClientsPaginatedDto
            {
                DataCount = await _clientRepository.CountClientsByNameAsync(request.Name),
                Clients = _mapper.Map<IEnumerable<ClientDto>>(clients)
            };

        }
    }
}
