
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ITD.PerrosPerdidos.Aplication.Interfaces.Presenters;
using ITD.PerrosPerdidos.Aplication.Interfaces;

namespace ITD.PerrosPerdidos.Aplication
{
        public static class DependencyConteiner
        {
            public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration)
            {



            
            return services;
        }
            
        }
    }



