using MediatR;

namespace OriontekClientsServer.Application.Features.Clients.Commands
{
    public class DeleteClientCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
