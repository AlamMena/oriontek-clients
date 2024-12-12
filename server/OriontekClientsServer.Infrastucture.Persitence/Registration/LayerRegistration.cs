using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OriontekClientsServer.Domain.Interfaces;
using OriontekClientsServer.Domain.Repositories;
using OriontekClientsServer.Infrastucture.Persitence.Contexts;
using OriontekClientsServer.Infrastucture.Persitence.Repositories.Clients;
using OriontekClientsServer.Infrastucture.Persitence.Repositories.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Infrastucture.Persitence.Registration
{
    public static class LayerRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                        m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)),
                ServiceLifetime.Scoped);

            //Inyecciones de dependencias.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
