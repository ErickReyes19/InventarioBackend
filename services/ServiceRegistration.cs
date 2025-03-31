using Inventario.interfaces.IEmpleado;
using Inventario.interfaces;
using Inventario.Repositories;
using Inventario.services;
using Inventario.interfaces.IUsuario;
using Inventario.repositories;
using Inventario.interfaces.Rol;
using Inventario.interfaces.ILogin;

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
        //Login
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<ILoginService, LoginService>();  

        //Empresa
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<IEmpresaService, EmpresaService>();  

        //Categoria
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<ICategoriaService, CategoriaService>();  

        //Asignaciones
        services.AddScoped<IAsignaciones, AsingacionesService>(); 
    }
}
