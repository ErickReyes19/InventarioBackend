using Inventario.interfaces.IMarca;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DbContextInventario _dbContextInventario;

        public MarcaRepository(DbContextInventario inventarioDb)
        {
            _dbContextInventario = inventarioDb;
        }
        public async Task<IEnumerable<Marca>> GetMarcas()
        {
            return await _dbContextInventario.Marca.Include("Empresa").ToListAsync();
        }
        public async Task<IEnumerable<Marca>> GetMarcasActivas()
        {
            return await _dbContextInventario.Marca.Where(c => c.activo == true).Include("Empresa").ToListAsync();
        }
        public async Task<IEnumerable<Marca>> GetMarcasActivasByEmpresaId(string id)
        {
            return await _dbContextInventario.Marca.Where(c => c.activo == true && c.Empresa_id == id).Include("Empresa").ToListAsync();
        }
        public async Task<IEnumerable<Marca>> GetMarcasByEmpresaId(string id)
        {
            return await _dbContextInventario.Marca.Where(c => c.Empresa_id == id).Include("Empresa").ToListAsync();
        }
        public async Task<Marca> GetMarcasById(string id)
        {
            return await _dbContextInventario.Marca.Where(c => c.Id == id).Include("Empresa").FirstOrDefaultAsync();
        }
        public async Task<Marca> GetMarcasByIdAndEmpresa(string id, string idEmpresa)
        {
            return await _dbContextInventario.Marca.Where(c => c.Id == id && c.Empresa_id == idEmpresa).Include("Empresa").FirstOrDefaultAsync();
        }

        public async Task<Marca> PostMarcas(Marca marca)
        {
            var result = await _dbContextInventario.Marca.AddAsync(marca);
            await _dbContextInventario.SaveChangesAsync();

            var usuarioWithIncludes = await _dbContextInventario.Marca.Include(u => u.Empresa)
                .Include(u => u.Empresa).FirstOrDefaultAsync(u => u.Id == marca.Id);
            return usuarioWithIncludes!;
        }
        public async Task<Marca> PutMarcas(Marca marca)
        {

            _dbContextInventario.Entry(marca).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return marca;
        }
    }
}
