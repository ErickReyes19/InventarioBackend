using System;
using System.Linq;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashBackend.Data
{
    public class Seeder
    {
        private readonly DbContextInventario _context;
        private readonly bool _resetData;

        public Seeder(DbContextInventario context, bool resetData = false)
        {
            _context = context;
            _resetData = resetData;
        }
        public void Seed()
        {
            if (_resetData && !_context.Usuarios.Any()) 
            {
                _context.Permisos.RemoveRange(_context.Permisos);
                _context.Roles.RemoveRange(_context.Roles);
                _context.Usuarios.RemoveRange(_context.Usuarios);
                _context.Empleados.RemoveRange(_context.Empleados);
                _context.Empresa.RemoveRange(_context.Empresa);
                _context.SaveChanges();
            }

            var empresa = new Empresa
            {
                Id = Guid.NewGuid().ToString(),
                nombre = "ComercialPineda",
                activo = true,
                adicionado_por = "Sistema",
                modificado_por = "Sistema",
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow
            };
            _context.Empresa.Add(empresa);
            _context.SaveChanges();

            if (!_context.Permisos.Any())
            {
                _context.Permisos.AddRange(

                   
                    new Permiso { Id = Guid.NewGuid().ToString(), Nombre = "ver_clientes", Descripcion = "Permiso para ver clientes", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Activo = true },
                    new Permiso { Id = Guid.NewGuid().ToString(), Nombre = "crear_clientes", Descripcion = "Permiso para crear clientes", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Activo = true },
                    new Permiso { Id = Guid.NewGuid().ToString(), Nombre = "editar_cliente", Descripcion = "Permiso para editar clientes", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Activo = true },
                    new Permiso { Id = Guid.NewGuid().ToString(), Nombre = "view_cliente", Descripcion = "Permiso para ver detalle de cliente", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Activo = true }

                    );
                _context.SaveChanges();
            }

            var adminRole = _context.Roles.FirstOrDefault(r => r.Nombre == "Administrador");
            if (adminRole == null)
            {
                adminRole = new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Administrador",
                    Descripcion = "Rol con acceso total al sistema",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Activo = true
                };

                _context.Roles.Add(adminRole);
                _context.SaveChanges();
            }


            var allPermisos = _context.Permisos.ToList();
            if (!adminRole.RolePermisos.Any())
            {
                foreach (var permiso in allPermisos)
                {
                    adminRole.RolePermisos.Add(new RolePermiso
                    {
                        RolId = adminRole.Id,
                        PermisoId = permiso.Id
                    });
                }
                _context.SaveChanges();
            }

            var empleado = _context.Empleados.FirstOrDefault(e => e.correo == "efrain.aguirre@gmail.com");
            if (empleado == null)
            {
                empleado = new Empleado
                {
                    id = Guid.NewGuid().ToString(),
                    nombre = "Jose Efrain",
                    apellido = "Aguirre",
                    activo = true,
                    correo = "efrain.aguirre@gmail.com",
                    empresa_id= empresa.Id,
                    modificado_por= "Sistema",
                    adicionado_por="Sistema",
                    edad = 50,
                    genero = "Masculino",
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow
                };

                _context.Empleados.Add(empleado);
                _context.SaveChanges();
            }

            if (!_context.Usuarios.Any(u => u.usuario == "Efrain.Aguirre"))
            {
                var usuario = new Usuario
                {
                    id = Guid.NewGuid().ToString(),
                    usuario = "Efrain.Aguirre",
                    contrasena = "admin", 
                    empresa_id= empresa.Id,
                    empleado_id = empleado.id,
                    role_id = adminRole.Id,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                    activo = true
                };

                
                usuario.contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.contrasena);

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }
    }
}
