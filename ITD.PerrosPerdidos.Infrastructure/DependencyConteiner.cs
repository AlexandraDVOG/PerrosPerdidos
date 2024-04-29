
using ITD.PerrosPerdidos.Application.Interfaces;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ITD.PerrosPerdidos.Infrestuctura
{
    public static class DependencyConteiner
    {
        public static   IServiceCollection AddInfrestucture(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddScoped<IAdministradorRepositoryContext, AdministradorRepositoryContext>();
            return services;

        }

    }
}
