using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DbContextInventario _dbContextInventario;

        public EmpresaRepository (DbContextInventario repositoryInventario)
        {
            _dbContextInventario = repositoryInventario;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresas()
        {
            return await _dbContextInventario.Empresa.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetEmpresasActivas()
        {
            return await _dbContextInventario.Empresa.Where(e => e.activo == true).ToListAsync();
        }

        public async Task<Empresa> GetEmpresaById(string id)
        {
            return await _dbContextInventario.Empresa.Where(e=> e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Empresa>PostEmpresa(Empresa empresa)
        {
            var result = await _dbContextInventario.Empresa.AddAsync(empresa);
            await _dbContextInventario.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Empresa> PutEmpresa(Empresa empresa)
        {

            _dbContextInventario.Entry(empresa).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return empresa;
        }


    }
}
