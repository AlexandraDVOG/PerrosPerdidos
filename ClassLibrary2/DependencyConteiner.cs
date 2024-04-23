
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.Context;
using ITD.PerrosPerdidos.Aplication.Interfaces;

namespace ITD.PerrosPerdidos.Infrestuctura
{
    public static class DependencyConteiner
    {
        public static   IServiceCollection AddInfrestructura(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddScoped<IAdministradorRepositoryContext, AdministradorRepostoryContext>();
            return services;

        }

    }
}
