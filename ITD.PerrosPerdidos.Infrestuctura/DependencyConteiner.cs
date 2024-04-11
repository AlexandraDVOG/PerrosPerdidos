using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestuctura
{
    public static class DependencyConteiner
    {
        public static   IServiceCollection AddInfrestucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticatio", null);

            services.AddScoped<ISimulacionContextRepository, SimulacionContextRepository > ();
            return services;

        }

    }
}
