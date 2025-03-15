using Inventario.interfaces.IEmpleado;
using Inventario.interfaces;
using Inventario.Repositories;
using Inventario.services;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        // Registrar todos los servicios aquí
        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<IEmpleadoService, EmpleadoService>();  
        services.AddScoped<IAsignaciones, AsingacionesService>(); 
    }
}
