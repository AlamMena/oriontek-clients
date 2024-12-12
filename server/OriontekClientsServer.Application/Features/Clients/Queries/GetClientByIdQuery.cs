using AutoMapper;
using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
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
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdCommand, ClientWithAddressesDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientWithAddressesDto> Handle(GetClientByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = await _clientRepository.GetClientByIdWithAddressesAsync(request.Id);

                if (client == null)
                {
                    throw new DomainException("Client not found", (int)HttpStatusCode.NotFound);
                }

                var clientResponse = _mapper.Map<ClientWithAddressesDto>(client);

                return clientResponse;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
