using OriontekClientsServer.Domain.Common;

namespace OriontekClientsServer.Domain.Entities;

public class Client : CoreEntity
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Identification { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ICollection<ClientAddress> Addresses { get; set; } = [];
}