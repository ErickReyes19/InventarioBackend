using Inventario.interfaces.IUsuario;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class UsuarioRepositoy: IUsuarioRepository
    {
        private readonly DbContextInventario _dbContextInventario;

        public UsuarioRepositoy(DbContextInventario dbContextInventario)
        {
            _dbContextInventario = dbContextInventario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _dbContextInventario.Usuarios.Include("Empleado").Include("Role").ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosActivos()
        {
            return await _dbContextInventario.Usuarios.Include("Empleado").Include("Role").Where(u => u.activo == true).ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(string id)
        {
            var usuario = await _dbContextInventario.Usuarios.Include("Empleado").Include("Role").Where(u => u.id == id).FirstOrDefaultAsync(); 
            return usuario;
        }

        public async Task<Usuario>PostUsuario(Usuario usuario)
        {
            var usuarioCreate = await _dbContextInventario.Usuarios.AddAsync(usuario);
            await _dbContextInventario.SaveChangesAsync();

            var usuarioWithIncludes = await _dbContextInventario.Usuarios.Include(u => u.Role)
                .Include(u => u.Empleado).FirstOrDefaultAsync(u => u.id == usuario.id);
            return usuarioWithIncludes!;
        }

        public async Task<Usuario> PutUsuario(Usuario usuario)
        {
            _dbContextInventario.Entry(usuario).State = EntityState.Modified;
            await _dbContextInventario.SaveChangesAsync();

            return await _dbContextInventario.Usuarios.Include(u => u.Role).Include(u => u.Empleado).FirstOrDefaultAsync(u => u.id == usuario.id);
        }





    }
}
