using Inventario.interfaces.IEmpleado;
using Inventario.interfaces;
using Inventario.Repositories;
using Inventario.services;
using Inventario.interfaces.IUsuario;
using Inventario.repositories;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        // Empleado
        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<IEmpleadoService, EmpleadoService>();          
        // Usuario
        services.AddScoped<IUsuarioRepository, UsuarioRepositoy>();
        services.AddScoped<IUsuarioService, UsuarioService>();  

        //Asignaciones
        services.AddScoped<IAsignaciones, AsingacionesService>(); 
    }
}
