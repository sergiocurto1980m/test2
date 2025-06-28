using Microsoft.Extensions.DependencyInjection;
using Application.Services; // Asegúrate de que este `using` apunte a donde están las interfaces y servicios
using Application.Interfaces;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registro de servicios concretos con sus interfaces
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProductoService, ProductoService>();
            // Agrega aquí más servicios según los vayas creando
            // services.AddScoped<IOtroService, OtroService>();

            return services;
        }
    }
}