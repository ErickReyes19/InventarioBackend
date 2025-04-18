﻿using Inventario.interfaces.Rol;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly DbContextInventario _dbContextInventario;
        public RolRepository(DbContextInventario dbContextInventario)
        {
            _dbContextInventario = dbContextInventario;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _dbContextInventario.Roles.ToListAsync();
        }
        public async Task<IEnumerable<Role>> GetRolesActivos()
        {
            return await _dbContextInventario.Roles.Where(r => r.Activo == true).ToArrayAsync();
        }
        public async Task<Role> GetRolesById(string id)
        {
            return await _dbContextInventario.Roles.Where(r => r.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Role> PostRol(Role rol)
        {
            var rolCreate = await _dbContextInventario.Roles.AddAsync(rol);
            await _dbContextInventario.SaveChangesAsync();
            return rolCreate.Entity;
        }
        public async Task<Role> PutRol(Role rol, string id)
        {
            _dbContextInventario.Entry(rol).State = EntityState.Modified;
            await _dbContextInventario.SaveChangesAsync();
            return rol;
        }

        public async Task<bool> AssignPermissions(string roleId, List<string> ids)
        {

            var existingPermissions = _dbContextInventario.RolePermiso.Where(rp => rp.RolId == roleId);
            _dbContextInventario.RolePermiso.RemoveRange(existingPermissions);

            var permisos = await _dbContextInventario.Permisos.Where(p => ids.Contains(p.Id)).ToListAsync();

            var rolePermisos = permisos.Select(p => new RolePermiso
            {
                RolId = roleId,
                PermisoId = p.Id
            }).ToList();

            _dbContextInventario.RolePermiso.AddRange(rolePermisos);

            var result = await _dbContextInventario.SaveChangesAsync();

            return result > 0;
        }


    }
}
