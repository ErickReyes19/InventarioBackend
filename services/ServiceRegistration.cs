using Inventario.interfaces.IEmpleado;
using Inventario.interfaces;
using Inventario.Repositories;
using Inventario.services;
using Inventario.interfaces.IUsuario;
using Inventario.repositories;
using Inventario.interfaces.Rol;

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
        //Rol
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<IRolesService, RolService>();  

        //Asignaciones
        services.AddScoped<IAsignaciones, AsingacionesService>(); 
    }
}
