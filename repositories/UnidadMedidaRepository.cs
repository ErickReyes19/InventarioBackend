using Inventario.interfaces.UnidadMedida;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly DbContextInventario _dbContextInventario;
        public UnidadMedidaRepository(DbContextInventario inventarioDb)
        {
            _dbContextInventario = inventarioDb;
        }
        public async Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedida()
        {
            return await _dbContextInventario.UnidadDeMedida.Include("Empresa").ToListAsync();
        }
        public async Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedidaActivas()
        {
            return await _dbContextInventario.UnidadDeMedida.Where(c => c.activo == true).Include("Empresa").ToListAsync();
        }
        public async Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedidaActivasByEmpresaId(string id)
        {
            return await _dbContextInventario.UnidadDeMedida.Where(c => c.activo == true && c.activo == true).Include("Empresa").ToListAsync();
        }
        public async Task<IEnumerable<UnidadDeMedida>> GetUnidadesMedidaByEmpresaId(string id)
        {
            return await _dbContextInventario.UnidadDeMedida.Where(c => c.Empresa_id == id).Include("Empresa").ToListAsync();
        }
        public async Task<UnidadDeMedida> GetUnidadesMedidaById(string id)
        {
            return await _dbContextInventario.UnidadDeMedida.Where(c => c.Id == id).Include("Empresa").FirstOrDefaultAsync();
        }
        public async Task<UnidadDeMedida> GetUnidadesMedidaByIdAndEmpresa(string id, string idEmpresa)
        {
            return await _dbContextInventario.UnidadDeMedida.Where(c => c.Id == id && c.Empresa_id == idEmpresa).Include("Empresa").FirstOrDefaultAsync();
        }
        public async Task<UnidadDeMedida> PostUnidadesMedida(UnidadDeMedida unidadMedida)
        {
            var result = await _dbContextInventario.UnidadDeMedida.AddAsync(unidadMedida);
            await _dbContextInventario.SaveChangesAsync();

            var unidadMedidaWithIncludes = await _dbContextInventario.UnidadDeMedida.Include(u => u.Empresa)
                .Include(u => u.Empresa).FirstOrDefaultAsync(u => u.Id == unidadMedida.Id);
            return unidadMedidaWithIncludes!;
        }
        public async Task<UnidadDeMedida> PutUnidadesMedida(UnidadDeMedida unidadMedida)
        {

            _dbContextInventario.Entry(unidadMedida).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return unidadMedida;
        }
    }
}
