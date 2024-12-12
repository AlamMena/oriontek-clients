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
    public class CreateClientHandler : IRequestHandler<Requests.CreateClientCommand, ClientDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public CreateClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = _mapper.Map<Client>(request);
                await _clientRepository.AddAsync(client);

                var response = _mapper.Map<Client, ClientDto>(client);

                return response;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
