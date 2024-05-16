
using ITD.PerrosPerdidos.Application.Interfaces;
using ITD.PerrosPerdidos.Application.Interfaces.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ITD.PerrosPerdidos.Application
{
    public static class DependencyConteiner
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdministradorPresenter, AdministradorLogic>();




            return services;
        }

    }
}



