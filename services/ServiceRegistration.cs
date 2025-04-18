﻿using Inventario.interfaces.IEmpleado;
using Inventario.interfaces;
using Inventario.Repositories;
using Inventario.services;
using Inventario.interfaces.IUsuario;
using Inventario.repositories;
using Inventario.interfaces.Rol;
using Inventario.interfaces.ILogin;
using Inventario.interfaces.IMarca;
using Inventario.interfaces.UnidadMedida;
using Inventario.interfaces.IProducto;
using Inventario.interfaces.IPrecioProducto;

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

        //Marca
        services.AddScoped<IMarcaRepository, MarcaRepository>();
        services.AddScoped<IMarcaService, MarcaService>();  
        
        //Unidad de medida
        services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
        services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();  
        
        //Productos
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IProductoService, ProductoService>();  
        
        //PrecioProducto
        services.AddScoped<IPrecioProductoRepository, PrecioProductoRepository>();
        services.AddScoped<IPrecioProductoService, PrecioProductoService>();  

        //Asignaciones
        services.AddScoped<IAsignaciones, AsingacionesService>(); 
    }
}
