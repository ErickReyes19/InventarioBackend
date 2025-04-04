﻿// <auto-generated />
using System;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventario.Migrations
{
    [DbContext(typeof(DbContextInventario))]
    partial class DbContextInventarioModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Categoria", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Empresa_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<ulong>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Empresa_id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Empresa", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<ulong>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Inventario.Models.Empleado", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<ulong>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("edad")
                        .HasColumnType("int");

                    b.Property<string>("empresa_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.HasIndex("empresa_id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Inventario.Models.Usuario", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<ulong>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("empleado_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("empresa_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<string>("role_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.HasIndex("empleado_id")
                        .IsUnique();

                    b.HasIndex("empresa_id");

                    b.HasIndex("role_id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Marca", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Empresa_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<ulong>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Empresa_id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("MovimientoInventario", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Modificado_por")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Producto_id")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Producto_id");

                    b.ToTable("MovimientoInventario");
                });

            modelBuilder.Entity("Permiso", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool?>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("PrecioProductos", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Producto_id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Producto_id");

                    b.ToTable("PrecioProducto");
                });

            modelBuilder.Entity("Producto", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Categoria_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Empresa_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Marca_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnidadMedida_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<ulong>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Categoria_id");

                    b.HasIndex("Empresa_id");

                    b.HasIndex("Marca_id");

                    b.HasIndex("UnidadMedida_id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RolePermiso", b =>
                {
                    b.Property<string>("RolId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("PermisoId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("RolId", "PermisoId");

                    b.HasIndex("PermisoId");

                    b.ToTable("RolePermiso", (string)null);
                });

            modelBuilder.Entity("UnidadDeMedida", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Empresa_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<ulong>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("adicionado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("modificado_por")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Empresa_id");

                    b.ToTable("UnidadDeMedida");
                });

            modelBuilder.Entity("Categoria", b =>
                {
                    b.HasOne("Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("Empresa_id");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Inventario.Models.Empleado", b =>
                {
                    b.HasOne("Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("empresa_id");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Inventario.Models.Usuario", b =>
                {
                    b.HasOne("Inventario.Models.Empleado", "Empleado")
                        .WithOne("Usuario")
                        .HasForeignKey("Inventario.Models.Usuario", "empleado_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("empresa_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Role", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Empresa");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Marca", b =>
                {
                    b.HasOne("Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("Empresa_id");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MovimientoInventario", b =>
                {
                    b.HasOne("Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("Producto_id");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PrecioProductos", b =>
                {
                    b.HasOne("Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("Producto_id");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Producto", b =>
                {
                    b.HasOne("Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("Categoria_id");

                    b.HasOne("Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("Empresa_id");

                    b.HasOne("Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("Marca_id");

                    b.HasOne("UnidadDeMedida", "UnidadMedida")
                        .WithMany()
                        .HasForeignKey("UnidadMedida_id");

                    b.Navigation("Categoria");

                    b.Navigation("Empresa");

                    b.Navigation("Marca");

                    b.Navigation("UnidadMedida");
                });

            modelBuilder.Entity("RolePermiso", b =>
                {
                    b.HasOne("Permiso", "Permiso")
                        .WithMany("RolePermisos")
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Role", "Rol")
                        .WithMany("RolePermisos")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("UnidadDeMedida", b =>
                {
                    b.HasOne("Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("Empresa_id");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Inventario.Models.Empleado", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Permiso", b =>
                {
                    b.Navigation("RolePermisos");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Navigation("RolePermisos");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
