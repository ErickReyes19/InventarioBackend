﻿

using Inventario.interfaces.IEmpleado;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly DbContextInventario _dbContextInventario;

        public EmpleadoRepository(DbContextInventario dbContextInventario)
        {
            _dbContextInventario = dbContextInventario;
        }
        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _dbContextInventario.Empleados.Include("Usuario").ToListAsync();
        }        
        public async Task<Empleado?> GetEmpleadoById(string id)
        {
            return await _dbContextInventario.Empleados.Where(e => e.id == id).FirstOrDefaultAsync() ?? null;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosActivos()
        {
            return await _dbContextInventario.Empleados.Where(e => e.activo == true).ToListAsync();
        }

        public async Task<Empleado> PostEmpleados( Empleado empleado)
        {
            var result = await _dbContextInventario.Empleados.AddAsync(empleado);
            await _dbContextInventario.SaveChangesAsync(); 
            return result.Entity; 
        }
        public async Task<Empleado> PutEmpleados(string id, Empleado empleado)
        {

            _dbContextInventario.Entry(empleado).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return empleado;
        }

    }
}
