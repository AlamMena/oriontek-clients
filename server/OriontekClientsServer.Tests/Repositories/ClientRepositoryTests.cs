using Microsoft.EntityFrameworkCore;
using OriontekClientsServer.Domain.Entities;
using OriontekClientsServer.Infrastucture.Persitence.Contexts;
using OriontekClientsServer.Infrastucture.Persitence.Repositories.Clients;

namespace OriontekClientsServer.Tests
{
    namespace OriontekClientsServer.Tests.Repositories.Clients
    {
        public class ClientRepositoryTests
        {
            private readonly ClientRepository _clientRepository;
            private readonly ApplicationContext _context;


            public ClientRepositoryTests()
            {
                _context = new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
                    .UseInMemoryDatabase("TestDb").Options);
                _clientRepository = new ClientRepository(_context);
            }

            [Fact]
            public async Task Should_Create_Client_And_Add_Address()
            {
                // Arrange
                var client = new Client
                {
                    Name = "John Doe",
                    LastName = "Mena",
                    PhoneNumber = "1234567890",
                    Email = "john@example.com",
                    Identification = "402-1389763-6",
                    Addresses =
                    [
                      new() { Street = "123 Main St", City = "Santo Domingo", ZipCode = "4020-120" }
                    ]
                };
                await _clientRepository.AddAsync(client);
            }
        }

    }

}