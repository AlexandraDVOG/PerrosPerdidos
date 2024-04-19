using ITD.PerrosPerdidos.Aplication.Presenters;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.ITD.PerrosPerdidos.Infrestuctura;
using ITD.PerrosPerdidos.Infrestuctura;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication
{
        public static class DependencyConteiner
        {
            public static IServiceCollection AddInfrestucture(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddAuthentication("BasicAuthentication")
                        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticatio", null);

                services.AddScoped<IPermisosPresenter, PermisosPresenter>(); 
                services.AddScoped<ISimulacionContextRepository, SimulacionContextRepository>();
                return services;
            }
            
        }
    }



