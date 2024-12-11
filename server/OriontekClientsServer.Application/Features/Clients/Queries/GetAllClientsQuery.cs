using AutoMapper;
using MediatR;
using OriontekClientsServer.Application.Dtos.Clients;
using OriontekClientsServer.Application.Features.Clients.Requests;
using OriontekClientsServer.Domain.Exceptions;
using OriontekClientsServer.Domain.Interfaces;
using System.Net;

namespace OriontekClientsServer.Application.Features.Clients.Queries
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsRequest, ClientsPaginatedDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetAllClientsQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientsPaginatedDto> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var clients = await _clientRepository.GetAllPaginatedAsync(request.Page, request.Limit);

                return new ClientsPaginatedDto
                {
                    DataCount = await _clientRepository.CountAsync(),
                    Clients = _mapper.Map<IEnumerable<ClientDto>>(clients)
                };
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
