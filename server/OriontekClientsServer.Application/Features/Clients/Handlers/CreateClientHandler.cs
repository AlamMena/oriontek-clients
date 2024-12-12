using AutoMapper;
using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using OriontekClientsServer.Application.Features.Clients.Requests;
using OriontekClientsServer.Domain.Entities;
using OriontekClientsServer.Domain.Exceptions;
using OriontekClientsServer.Domain.Interfaces;
using System.Net;

namespace OriontekClientsServer.Application.Features.Clients.Commands
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientWithAddressesDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public CreateClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientWithAddressesDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clientWithSameIdentification = await _clientRepository.GetClientByIdentificationAsync(request.Identification);
                if (clientWithSameIdentification != null)
                {
                    throw new DomainException("The identification number is already registered", (int)HttpStatusCode.Conflict);
                }

                var client = _mapper.Map<Client>(request);
                await _clientRepository.AddAsync(client);

                var response = _mapper.Map<Client, ClientWithAddressesDto>(client);

                return response;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
