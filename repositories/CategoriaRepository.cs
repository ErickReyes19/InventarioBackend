using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class CategoriaRepository :ICategoriaRepository
    {
        private readonly DbContextInventario _dbContextInventario;

        public CategoriaRepository (DbContextInventario inventarioDb)
        {
            _dbContextInventario = inventarioDb;
        }
        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _dbContextInventario.Categoria.Include("Empresa").ToListAsync();
        }        
        public async Task<IEnumerable<Categoria>> GetCategoriaActivas()
        {
            return await _dbContextInventario.Categoria.Where(c => c.activo == true).Include("Empresa").ToListAsync();
        }        
        public async Task<IEnumerable<Categoria>> GetCategoriaActivasByEmpresaId(string id)
        {
            return await _dbContextInventario.Categoria.Where(c => c.activo == true &&  c.activo == true).Include("Empresa").ToListAsync();
        }
        public async Task<IEnumerable<Categoria>> GetCategoriasByEmpresaId(string id)
        {
            return await _dbContextInventario.Categoria.Where(c => c.Empresa_id == id).Include("Empresa").ToListAsync();
        }        
        public async Task<Categoria> GetCategoriaById(string id)
        {
            return await _dbContextInventario.Categoria.Where(c => c.Id == id).Include("Empresa").FirstOrDefaultAsync();
        }        
        public async Task<Categoria> GetCategoriaByIdAndEmpresa(string id, string idEmpresa)
        {
            return await _dbContextInventario.Categoria.Where(c => c.Id == id && c.Empresa_id == idEmpresa).Include("Empresa").FirstOrDefaultAsync();
        }

        public async Task<Categoria> PostCategoria(Categoria categoria)
        {
            var result = await _dbContextInventario.Categoria.AddAsync(categoria);
            await _dbContextInventario.SaveChangesAsync();

            var usuarioWithIncludes = await _dbContextInventario.Categoria.Include(u => u.Empresa)
                .Include(u => u.Empresa).FirstOrDefaultAsync(u => u.Id == categoria.Id);
            return usuarioWithIncludes!;
        }
        public async Task<Categoria> PutCategoria(Categoria categoria)
        {

            _dbContextInventario.Entry(categoria).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return categoria;
        }
    }
}
