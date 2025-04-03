using Inventario.interfaces.IPrecioProducto;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.repositories
{
    public class PrecioProductoRepository :IPrecioProductoRepository
    {
        private readonly DbContextInventario _dbContextInventario;
        public PrecioProductoRepository(DbContextInventario context)
        {
            _dbContextInventario = context;
        }
        public async Task<IEnumerable<PrecioProductos>>  GetAllPrecioProductoByIdProducto(string id)
        {
            return await _dbContextInventario.PrecioProducto.Where(p => p.Producto_id == id).Include("Producto").ToListAsync();
        }
        public async Task<PrecioProductos> GetActualPrecioProductoByIdProducto(string id)
        {
            return await _dbContextInventario.PrecioProducto.Where(p => p.FechaFin == null && p.Producto_id == id).Include("Producto").FirstOrDefaultAsync();
        }        
        public async Task<PrecioProductos> GetPrecioProductoByIdProductoById(string id)
        {
            return await _dbContextInventario.PrecioProducto.Where(p => p.Id == id).Include("Producto").FirstOrDefaultAsync();
        }
        public async Task<PrecioProductos> PostPrecioProducto( PrecioProductos precioProducto)
        {
            var result = await _dbContextInventario.PrecioProducto.AddAsync(precioProducto);
            await _dbContextInventario.SaveChangesAsync();

            var precioProductoWithIncludes = await _dbContextInventario.PrecioProducto.Include(u => u.Producto)
                .Include(u => u.Producto).FirstOrDefaultAsync(u => u.Id == precioProducto.Id);
            return precioProductoWithIncludes!;
        }
        public async Task<PrecioProductos> PutPrecioProducto(PrecioProductos precioProducto)
        {

            _dbContextInventario.Entry(precioProducto).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return precioProducto;
        }        
        public async Task<PrecioProductos> UpdatePrecioProducto(PrecioProductos precioProducto)
        {

            _dbContextInventario.Entry(precioProducto).State = EntityState.Modified;

            await _dbContextInventario.SaveChangesAsync();

            return precioProducto;
        }
    }
}
