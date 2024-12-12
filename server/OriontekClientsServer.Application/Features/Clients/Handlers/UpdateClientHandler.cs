using AutoMapper;
using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using OriontekClientsServer.Application.Features.Clients.Commands;
using OriontekClientsServer.Application.Features.Clients.Requests;
using OriontekClientsServer.Domain.Entities;
using OriontekClientsServer.Domain.Exceptions;
using OriontekClientsServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Features.Clients.Handlers
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, ClientWithAddressesDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public UpdateClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientWithAddressesDto> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var dbClient = await _clientRepository.GetByIdAsync(request.Id);

            if (dbClient == null)
            {
                throw new DomainException("The client doesn't exists!", (int)HttpStatusCode.NotFound);
            }

            var clientWithSameIdentification = await _clientRepository.GetClientByIdentificationAsync(request.Identification);
            if (clientWithSameIdentification != null && clientWithSameIdentification.Id != request.Id)
            {
                throw new DomainException("The identification number is already registered", (int)HttpStatusCode.Conflict);
            }

            var client = _mapper.Map<Client>(request);

            // performing adding 
            var newAddresses = client.Addresses.Where(d => d.Id == 0);
            if (newAddresses.Any())
            {
                await _clientRepository.AddClientAddresses(client.Id, newAddresses);
            }

            // performing update
            var addressesToUpdate = client.Addresses.Where(r => dbClient.Addresses.Any(e => e.Id == r.Id && e.Id != 0));
            if (addressesToUpdate.Any())
            {
                await _clientRepository.UpdateClientAddresses(client.Id, addressesToUpdate);
            }

            // performing delete
            var addressesToRemove = dbClient.Addresses.Where(r => !client.Addresses.Any(e => e.Id == r.Id && e.Id != 0));
            if (addressesToRemove.Any())
            {
                await _clientRepository.DeleteClientAddresses(client.Id, addressesToRemove);
            }

            await _clientRepository.UpdateAsync(client);
            var response = _mapper.Map<Client, ClientWithAddressesDto>(client);

            return response;
        }
    }
}
