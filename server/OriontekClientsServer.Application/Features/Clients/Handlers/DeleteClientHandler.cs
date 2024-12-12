using AutoMapper;
using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using OriontekClientsServer.Application.Features.Clients.Commands;
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
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, int>
    {

        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public DeleteClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dbClient = await _clientRepository.GetByIdAsync(request.Id);

                if (dbClient == null)
                {
                    throw new DomainException("The client doesn't exists!", (int)HttpStatusCode.NotFound);
                }

                var response = await _clientRepository.DeleteAsync(request.Id);

                return 1;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
