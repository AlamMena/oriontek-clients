using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Application.Registration
{
    public static class LayerRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // Register AutoMapper to map between objects
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register MediatR for implementing the mediator pattern
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()));
        }
    }
}
