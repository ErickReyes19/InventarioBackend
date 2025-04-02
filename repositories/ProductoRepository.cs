using Inventario.interfaces.IProducto;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbContextInventario _dbContextInventario;

        public ProductoRepository(DbContextInventario inventarioDb)
        {
            _dbContextInventario = inventarioDb;
        }
        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _dbContextInventario.Producto.Include("Empresa").Include("Marca").Include("Categoria").Include("UnidadMedida").ToListAsync();
        }
        public async Task<IEnumerable<Producto>> GetProductosActivas()
        {
            return await _dbContextInventario.Producto.Where(c => c.activo == true).Include("Empresa").Include("Marca").Include("Categoria").Include("UnidadMedida").ToListAsync();
        }
        public async Task<IEnumerable<Producto>> GetProductosActivasByEmpresaId(string id)
        {
            return await _dbContextInventario.Producto.Where(c => c.activo == true && c.activo == true).Include("Empresa").Include("Marca").Include("Categoria").Include("UnidadMedida").ToListAsync();
        }
        public async Task<IEnumerable<Producto>> GetProductosByEmpresaId(string id)
        {
            return await _dbContextInventario.Producto.Where(c => c.Empresa_id == id).Include("Empresa").Include("Marca").Include("Categoria").Include("UnidadMedida").ToListAsync();
        }
        public async Task<Producto> GetProductosById(string id)
        {
            return await _dbContextInventario.Producto.Where(c => c.Id == id).Include("Empresa").Include("Marca").Include("Categoria").Include("UnidadMedida").FirstOrDefaultAsync();
        }
        public async Task<Producto> GetProductosByIdAndEmpresa(string id, string idEmpresa)
        {
            return await _dbContextInventario.Producto.Where(c => c.Id == id && c.Empresa_id == idEmpresa).Include("Empresa").Include("Marca").Include("Categoria").Include("UnidadMedida").FirstOrDefaultAsync();
        }

        public async Task<Producto> PostProductos(Producto producto)
        {
            var result = await _dbContextInventario.Producto.AddAsync(producto);
            await _dbContextInventario.SaveChangesAsync();

            var usuarioWithIncludes = await _dbContextInventario.Producto.Include(u => u.Empresa)
                .Include(u => u.Empresa).FirstOrDefaultAsync(u => u.Id == producto.Id);
            return usuarioWithIncludes!;
        }
        public async Task<Producto> PutProductos(Producto producto)
        {

            _dbContextInventario.Entry(producto).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return producto;
        }
    }
}
