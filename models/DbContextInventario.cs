﻿using Microsoft.EntityFrameworkCore;

namespace Inventario.Models // Aquí faltaban llaves para definir el espacio de nombres correctamente
{
    public class DbContextInventario : DbContext
    {
        public DbContextInventario() { }

        public DbContextInventario(DbContextOptions<DbContextInventario> options) : base(options) { }

        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolePermiso> RolePermiso { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<UnidadDeMedida> UnidadDeMedida { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<PrecioProductos> PrecioProducto { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermiso>(entity =>
            {
                entity
                    .HasKey(rp => new { rp.RolId, rp.PermisoId });

                entity
                    .HasOne(rp => rp.Rol)
                    .WithMany(r => r.RolePermisos)
                    .HasForeignKey(rp => rp.RolId);

                entity
                    .HasOne(rp => rp.Permiso)
                    .WithMany(p => p.RolePermisos)
                    .HasForeignKey(rp => rp.PermisoId);

                entity
                    .ToTable("RolePermiso");

            });


            base.OnModelCreating(modelBuilder);
        }


    }
}
