using ITD.PerrosPerdidos.Infrestuctura.Repostory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.ITD.PerrosPerdidos.Infrestuctura;

namespace ITD.PerrosPerdidos.Infrestuctura
{
    public static class DependencyConteiner
    {
        public static   IServiceCollection AddInfrestucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticatio", null);

            services.AddScoped<mas, SimulacionContextRepository > ();
            return services;

        }

    }
}
