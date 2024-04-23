
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ITD.PerrosPerdidos.Aplication.Interfaces.Presenters;
using ITD.PerrosPerdidos.Aplication.Interfaces;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.Context;

namespace ITD.PerrosPerdidos.Aplication
{
        public static class DependencyConteine
        {
            public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration)
            {



            services.AddScoped<IAdministradorRepositoryContext, AdministradorRepostoryContext>();
            return services;
        }
            
        }
    }



