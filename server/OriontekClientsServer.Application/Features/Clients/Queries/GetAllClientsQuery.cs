using AutoMapper;
using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using OriontekClientsServer.Application.Features.Clients.Requests;
using OriontekClientsServer.Domain.Exceptions;
using OriontekClientsServer.Domain.Interfaces;
using System.Net;

namespace OriontekClientsServer.Application.Features.Clients.Queries
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsCommand, ClientsPaginatedDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetAllClientsQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientsPaginatedDto> Handle(GetAllClientsCommand request, CancellationToken cancellationToken)
        {

            var clients = await _clientRepository.GetAllPaginatedAsync(request.Page, request.Limit);

            return new ClientsPaginatedDto
            {
                DataCount = await _clientRepository.CountAsync(),
                Clients = _mapper.Map<IEnumerable<ClientDto>>(clients)
            };

        }
    }
}
