using ComboBoxPublicos.WebApi.Aplicacion.Interfaces;
using ComboBoxPublicos.WebApi.Aplicacion.Servicios;
using ComboBoxPublicos.WebApi.Dominio.Interfaces;
using ComboBoxPublicos.WebApi.Dominio.Persistencia;
using ComboBoxPublicos.WebApi.Infraestructura.Repositorios;
using ComboBoxPublicos.WebApi.Transversal.Interfaces;
using ComboBoxPublicos.WebApi.Transversal.Modelos;

namespace ComboBoxPublicos.WebApi.Modules.Injection;

public static class InjectionExtensions
{

    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddSingleton<DapperContext>();
        services.AddScoped<ICiudadRepositorio, CiudadRepositorio>();
        services.AddScoped<ICiudadServicio, CiudadServicio>();
        services.AddScoped<IIndicativoServicio, IndicativoServicio>();
        services.AddScoped<IIndicativoRepositorio, IndicativoRepositorio>();

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }


}
