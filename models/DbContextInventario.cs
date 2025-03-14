
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermiso>()
                .HasKey(rp => new { rp.RolId, rp.PermisoId });

            modelBuilder.Entity<RolePermiso>()
                .HasOne(rp => rp.Rol)
                .WithMany(r => r.RolePermisos)
                .HasForeignKey(rp => rp.RolId);

            modelBuilder.Entity<RolePermiso>()
                .HasOne(rp => rp.Permiso)
                .WithMany(p => p.RolePermisos)
                .HasForeignKey(rp => rp.PermisoId);

            modelBuilder.Entity<RolePermiso>()
                .ToTable("RolePermiso");

            modelBuilder.Entity<Empleado>()
                .Property(e => e.id)
                .HasMaxLength(36)
                .IsFixedLength();

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nombre)
                .IsRequired();

            modelBuilder.Entity<Empleado>()
                .Property(e => e.apellido)
                .IsRequired();      
            
            modelBuilder.Entity<Empleado>()
                .Property(e => e.correo)
                .IsRequired();          
            
            modelBuilder.Entity<Empleado>()
                .Property(e => e.correo)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(e => e.id)
                .HasMaxLength(36)
                .IsFixedLength();

            modelBuilder.Entity<Permiso>()
                .Property(e => e.Id)
                .HasMaxLength(36)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.Id)
                .HasMaxLength(36)
                .IsFixedLength();



            base.OnModelCreating(modelBuilder);
        }


    }
}
