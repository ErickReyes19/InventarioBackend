using Inventario.models.Categoria;
using Inventario.models.PrecioProducto;

namespace Inventario.interfaces.IPrecioProducto
{
    public interface IPrecioProductoService
    {
        Task<IEnumerable<PrecioProductoDto>> GetAllPrecioProductoByIdProducto(string id);
        Task<PrecioProductoDto> GetActualPrecioProductoByIdProducto(string id);
        Task<PrecioProductoDto> GetPrecioProductoByIdProductoById(string id);
        Task<PrecioProductoDto> PostPrecioProducto( PrecioProductos precioProducto);
        Task<PrecioProductoDto> PutPrecioProducto(string id, PrecioProductos precioProducto);
        Task<PrecioProductoDto> UpdatePrecioProducto(string id, PrecioProductos precioProducto);
    }
}
